using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeExamples.Tests
{
    public  class Class3
    {

        public static void Run()
        {
            // Initialize the vocabulary checker with a list of valid English words.
            var vocabularyChecker = new VocabularyChecker("wordlist.txt");

            // Create a game with a list of words (all words must have the same length).
            List<string> words = new List<string> { "poker", "cover", "pesto" };
            var game = new WordGame(words, vocabularyChecker);

            // Display the initial state of the game
            Console.WriteLine("Game initialized. Partially revealed words:");
            DisplayGameState(game);

            // Sample game loop
            while (!game.IsGameComplete())
            {
                Console.Write("\nEnter your guess: ");
                string guess = Console.ReadLine().Trim().ToLower();

                if (game.SubmitGuess(guess))
                {
                    Console.WriteLine("Guess accepted.");
                }
                else
                {
                    Console.WriteLine("Invalid guess.");
                }

                DisplayGameState(game);
            }

            Console.WriteLine("\nGame Complete! Final state of words:");
            DisplayGameState(game);
            Console.WriteLine("Thank you for playing!");
        }

        static void DisplayGameState(WordGame game)
        {
            var currentState = game.GetGameStrings();
            foreach (var word in currentState)
            {
                Console.WriteLine(word);
            }
        }

    }

    class WordGame
    {
        private readonly List<string> words;              // Original words
        private List<char[]> partiallyRevealedWords;      // Partially revealed words as character arrays
        private VocabularyChecker vocabularyChecker;      // Vocabulary checker instance

        public WordGame(List<string> initialWords, VocabularyChecker vocabChecker)
        {
            if (initialWords == null || initialWords.Count == 0 || initialWords.Any(w => w.Length != initialWords[0].Length))
                throw new ArgumentException("Words must be non-empty and all of the same length.");

            words = initialWords;
            vocabularyChecker = vocabChecker;
            InitializeGame();
        }

        private void InitializeGame()
        {
            // Initialize each word as partially revealed with one random letter revealed
            var random = new Random();
            partiallyRevealedWords = new List<char[]>();

            foreach (var word in words)
            {
                char[] maskedWord = new string('*', word.Length).ToCharArray();
                int randomIndex = random.Next(word.Length);
                maskedWord[randomIndex] = word[randomIndex];
                partiallyRevealedWords.Add(maskedWord);
            }
        }

        public List<string> GetGameStrings()
        {
            // Convert each character array back to a string for display
            return partiallyRevealedWords.Select(chars => new string(chars)).ToList();
        }

        public bool SubmitGuess(string guess)
        {
            if (!vocabularyChecker.IsValidWord(guess) || guess.Length != words[0].Length)
                return false;

            bool exactMatch = false;
            int totalRevealed = 0;

            for (int i = 0; i < words.Count; i++)
            {
                if (IsFullyRevealed(i))
                    continue;

                if (guess == words[i])
                {
                    exactMatch = true;
                    partiallyRevealedWords[i] = words[i].ToCharArray(); // Reveal fully
                    continue; // Skip revealing for other words if exact match found
                }

                int revealedInThisWord = RevealMatchingCharacters(guess, i);
                totalRevealed += revealedInThisWord;
            }

            if (exactMatch)
            {
                Console.WriteLine("Exact match! You score 10 points!");
            }
            else if (totalRevealed > 0)
            {
                Console.WriteLine($"You revealed {totalRevealed} characters. Score: {totalRevealed} points.");
            }
            else
            {
                Console.WriteLine("No new characters revealed.");
                return false;
            }

            return true;
        }

        private int RevealMatchingCharacters(string guess, int wordIndex)
        {
            int revealedCount = 0;
            char[] wordArray = words[wordIndex].ToCharArray();
            char[] currentMaskedWord = partiallyRevealedWords[wordIndex];

            for (int j = 0; j < guess.Length; j++)
            {
                if (guess[j] == wordArray[j] && currentMaskedWord[j] == '*')
                {
                    currentMaskedWord[j] = wordArray[j];
                    revealedCount++;
                }
            }

            return revealedCount;
        }

        private bool IsFullyRevealed(int wordIndex)
        {
            return !partiallyRevealedWords[wordIndex].Contains('*');
        }

        public bool IsGameComplete()
        {
            return partiallyRevealedWords.All(word => !word.Contains('*'));
        }
    }

    class VocabularyChecker
    {
        private HashSet<string> validWords;

        public VocabularyChecker(string wordListFilePath)
        {
            validWords = new HashSet<string>(File.ReadAllLines(wordListFilePath).Select(w => w.Trim().ToLower()));
        }

        public bool IsValidWord(string word)
        {
            return validWords.Contains(word);
        }
    }
}
