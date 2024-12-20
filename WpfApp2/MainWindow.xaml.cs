using System;
using System.Windows;

namespace NumberGuessingGame
{
    public partial class MainWindow : Window
    {
        private int lowerBound;
        private int upperBound;
        private int targetNumber;
        private int player1Score = 0;
        private int player2Score = 0;
        private int currentPlayer = 1;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(LowerBoundTextBox.Text, out lowerBound) && int.TryParse(UpperBoundTextBox.Text, out upperBound) && lowerBound < upperBound)
            {
                Random random = new Random();
                targetNumber = random.Next(lowerBound, upperBound + 1); // Случайное число в заданном диапазоне

                // Обновляем статус игры
                StatusTextBlock.Text = $"Игрок {currentPlayer}, угадать число!";
                GuessTextBox.Clear();
                GuessTextBox.IsEnabled = true;
                Player1ScoreTextBlock.Text = $"Игрок 1: {player1Score}";
                Player2ScoreTextBlock.Text = $"Игрок 2: {player2Score}";
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректные значения для диапазона чисел.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CheckGuess_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(GuessTextBox.Text, out int playerGuess))
            {
                if (playerGuess == targetNumber)
                {
                    
                    if (currentPlayer == 1)
                    {
                        player1Score++;
                    }
                    else
                    {
                        player2Score++;
                    }

                   
                    currentPlayer = currentPlayer == 1 ? 2 : 1;

                   
                    StatusTextBlock.Text = $"Игрок {currentPlayer}, угадать число!";
                    GuessTextBox.Clear();
                    GuessTextBox.IsEnabled = false;
                }
                else
                {
                    
                    StatusTextBlock.Text = playerGuess > targetNumber ? "Загаданное число меньше!" : "Загаданное число больше!";
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите число для проверки.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
