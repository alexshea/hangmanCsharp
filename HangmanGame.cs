using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading,Tasks;

namespace Hangman
{
	class HangmanGame
	{
		private bool keepPlaying;
		private int guessesLeft;
		private string answer;
		private int lettersFound;
		private string[] guessedLetters;
		private int guessedLettersIndex;
		private string[] wordDisplay;

		public void Play()
		{
			Setup();

			while(keepPlaying)
			{
				DisplayPuzzle();
				PromptUser();
			}

			DisplayResult();
		}

		private void PromptUser()
		{
			bool validInput = false;
			while (!validInput)
			{
				Console.Write("Guess a letter");
				validInput = ParseInput(Console.ReadLine().ToUpper());
			}

			Console.WriteLine("\nPress enter to continue");
			Console.ReadLine();
		}

		private bool ParseInput(string input)
		{
			if (input.Length > 1)
			{
				if (input == answer)
				{
					Console.WriteLine("Correct buddy! You're super smart!");
					keepPlaying = false;
					return true;
				}
				else 
				{
					Console.WriteLine("Wrong answer, buddy!");
					guessesLeft--;
				}
			}
			else
			{
				if(guessedLetters.Contains(input))
				{
					Console.WriteLine("Already guessed {0}, buddy", input);
					return false;
				}
				bool foundLetterInAnswer = false;
				for (int = 0; i < answer.Length; i++)
				{
					if (input == answer[i].ToString())
					{
						foundLetterInAnswer = true;
						lettersFound++;
						wordDisplay[i] = input;
					}
				}

				if (foundLetterInAnswer)
				{
					Console.WriteLine("Excellent");
					if (lettersFound == answer.Length)
					{
						keepPlaying = false;
					}
				}
				else
				{
					Console.WriteLine("Letter not found, buddy");
					guessesLeft--;
				}
			}

			guessedLetters[guessedLettersIndex] = input;
			guessedLettersIndex++;

			if (guessesLeft == 0)
			{
				keepPlaying = false;
			}
		}

		private void DisplayResult()
		{
			if (guessesLeft > 0)
			{
				Console.WriteLine("You guessed the word correctly");
			}
			else 
			{
				Console.WriteLine("You lost the game! Oh no!");
			}
		}

		private void DisplayPuzzle()
		{
			Console.WriteLine("\nPuzzle: ");

			for (int i = 0; i < wordDisplay.Length; i++)
			{
				Console.Write("{0} ", wordDisplay[i]);
			}

			Console.WriteLine("\n\nYou have {0} guesses left.\n", guessesLeft);
		}

		private void Setup()
		{
			guessesLeft = 5;
			keepPlaying = true;
			guessedLetters = new String[26];
			guessedLettersIndex = 0;

			GetWordFromPlayer();
			CreateWordDisplay();
		}

		private void GetWordFromPlayer()
		{
			Console.Write("Enter the word to guess");
			answer = Console.ReadLine().ToUpper();
			Console.Clear();
		}

		private void CreateWordDisplay()
		{
			wordDisplay = new String[answer.Length];
			for (int i = 0; i < wordDisplay.Length; i++)
			{
				wordDisplay[i] = "_";
			}
		}
	}
}