using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeExamples.SortingSearching
{
    public class MeetingRoom
    {
        public int Id { get; set; }
        public int Time { get; set; }
        public int Counter { get; set; }    

        public int MeetinRoomNumber { get; set; }
    }

    public class MeetingRoom3_2402
    {

        public static int MostBooked(int n, int[][] meetings)
        {
            Comparer<int> comparer = Comparer<int>.Default;
            Array.Sort(meetings, (a, b) => { return a[0] - b[0]; });

            List<MeetingRoom> list = new List<MeetingRoom>();   
            for (int i = 1;i<=n;i++)
            {
                list.Add(new MeetingRoom { Id=i, Counter=0, MeetinRoomNumber=i-1, Time=0 });
            }

           
            foreach (var meeting in meetings)
            {
                (int id, bool isEmpty) = IsRoomEmpty(list, meeting);

                var list1 = list.Where(t => t.Id == id).First();
                if (isEmpty)
                {
                    list1.Counter++;
                    list1.Time = meeting[1];
                }
                else
                {
                    var timeInterval = meeting[1]-meeting[0];
                    list1.Time += timeInterval;
                    list1.Counter++;
                }
            }

            var maxMeetingHeld = list.Max(t => t.Counter);

            var coun = list.Count(t => t.Counter == maxMeetingHeld);
            if (coun == n)
            {
                return 0;
            }


            return list.Where(t => t.Counter == maxMeetingHeld).Select(t => t.MeetinRoomNumber).Min();
        }


        private static (int, bool) IsRoomEmpty(List<MeetingRoom> list, int[] meeting)
        {
            //   var result = list.Where(t => t.Counter == 0).OrderBy(t=> t.MeetinRoomNumber);
            //  if (result.Any())
            //  {
            //      return (result.First().Id, true);
            //  }

            var minMeetingRoom = list.Where(t => t.Time < meeting[0]);
            MeetingRoom finalMeetingRoom = null;
            if (minMeetingRoom.Any())
            {
                finalMeetingRoom = minMeetingRoom.OrderBy(t => t.MeetinRoomNumber).FirstOrDefault();
            }
            else
            {
                var result = list.Where(t => t.Counter == 0).OrderBy(t => t.MeetinRoomNumber);
                if (result.Any())
                {
                    return (result.First().Id, true);
                }

                finalMeetingRoom = list.Where(t => t.Time == list.Min(t => t.Time)).OrderBy(t => t.MeetinRoomNumber).FirstOrDefault();
            }

            return (finalMeetingRoom.Id, finalMeetingRoom.Counter==0?true:false);
        }
        private static (int, bool) IsRoomEmpty1(List<MeetingRoom> list, int[] meeting)
        {
           var result = list.Where(t => t.Counter == 0).OrderBy(t=> t.MeetinRoomNumber);
            if (result.Any())
            {
                return (result.First().Id, true);
            }

            var minMeetingRoom = list.Where(t => t.Time < meeting[0]);
            MeetingRoom finalMeetingRoom = null;
            if (minMeetingRoom.Any())
            {
                finalMeetingRoom =minMeetingRoom.OrderBy(t => t.MeetinRoomNumber).FirstOrDefault();
            }
            else
            {
                finalMeetingRoom = list.Where(t => t.Time == list.Min(t => t.Time)).OrderBy(t => t.MeetinRoomNumber).FirstOrDefault();
            }

            return (finalMeetingRoom.Id, false);
        }


        public static void Run()
        {
            int [][] nums = [[0, 10], [1, 5], [2, 7], [3, 4]];
            nums = [[12, 44], [27, 37], [48, 49], [46, 49], [24, 44], [32, 38], [21, 49], [13, 30]];
            int rooms = 4;

            var output = MostBooked(rooms, nums);

        }
    }
}
