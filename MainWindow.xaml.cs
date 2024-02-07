using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf1125_lesson0702
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string MyFIO { get; set; } = "Значение из привязки";
        public MainWindow()
        {
            InitializeComponent();
            // Создание свойств зависимостей
            // DependencyProperty - класс, с помощью которого
            // создаются свойства зависимости
            // Свойства зависимости могут работать только в
            // классах-наследниках класса DependencyObject
            // Класс DependencyObject содержит методы
            // для назначения и получения значения свойства
            // важно: работа происходит с типом object
            /*object o = 1; // упаковка
            o = "asd";
            o = true;

            bool b = (bool)o; */// распаковка
                                // Memory Leak
                                // object - ссылочный тип данных, значение хранится
                                // в области памяти "куча". Т.е. у нас есть ссылка
        // Скорее всего свойства зависимости могут
        // пригодиться только в одном случае:
        // при разработке новых компонентов wpf

            DataContext = this;
        }

        // свойства зависимости обычно идут в сочетании
        // с обычными свойствами
        // Обычное свойство позволяет прочитать или назначить
        // значение свойству зависимости
        // GetValue и SetValue - методы из класса DependencyObject
        public int MyProperty
        {
            get { return (int)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }
        // все свойства зависимости публичные статичные
        // включают в имени суффикс Property
        // инициализируются с помощью специального метода
        // DependencyProperty.Register - обычная регистрация

        // Порядок вызова метод в свойстве зависимости:
        // 1. Валидация
        // 2. Корректировка (если срабатывает корректировка, то идем на п.1)
        // 3. Уведомление об изменении

        // назначение и вычисление значения свойства
        // происходит в несколько этапов, поскольку затрагиваются
        // разные аспекты и окружающие элементы

        // Свойство автоматически отправляет уведомления всем 
        // привязкам об изменении
        // Если в xaml необходимо организовать привязку к 
        // свойству - оно должно быть свойством зависимости

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyPropertyProperty =
            DependencyProperty.Register(
                "MyProperty",  // Название свойства (то, что объявлено выше)
                typeof(int),   // Тип данных
                typeof(MainWindow),   // Указывается владелец
                new PropertyMetadata(100, MyChanged, MyCoerce),  // в метаданных можно указать
                                                                 // значение по умолчанию, метод корректировки назначаемого
                                                                 // значения, метод-подписка на событие изменения свойства
                Validate);

        private static bool Validate(object value)
        {   // true - значение валидно и его можно сохранить
            // false - наоборот
            if ((int)value == 0)
                return false;

            return true;
        }

        private static object MyCoerce(DependencyObject d, object baseValue)
        {
            int check = (int)baseValue;
            if (check < 0)
                baseValue = 10;
            return baseValue;
        }

        private static void MyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MessageBox.Show($"Значение свойства было изменено с {e.OldValue} на {e.NewValue}");
        }
        


    }
}
