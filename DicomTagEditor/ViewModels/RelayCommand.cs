using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DicomTagEditor.ViewModels
{
    /// <summary>
    /// Relays the UI command to the ViewModel.
    /// </summary>
    public class RelayCommand : ICommand
    {
        /// <summary>
        /// CanExecuteの結果に変更があったことを通知するイベント。
        /// WPFのCommandManagerのRequerySuggestedイベントをラップする形で実装しています。
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        private Action<object> execute;
        private Func<bool> canExecute;

        //public bool CanExecute(object parameter)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Execute(object parameter)
        //{
        //    throw new NotImplementedException();
        //}

        /// <summary>
        /// コマンドのExecuteメソッドで実行する処理を指定してDelegateCommandのインスタンスを
        /// 作成します。
        /// </summary>
        /// <param name="execute">Executeメソッドで実行する処理</param>
        public RelayCommand(Action<object> execute)
            : this(execute, () => true)
        {
        }

        /// <summary>
        /// コマンドのExecuteメソッドで実行する処理とCanExecuteメソッドで実行する処理を指定して
        /// DelegateCommandのインスタンスを作成します。
        /// </summary>
        /// <param name="execute">Executeメソッドで実行する処理</param>
        /// <param name="canExecute">CanExecuteメソッドで実行する処理</param>
        public RelayCommand(Action<object> execute, Func<bool> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }

            if (canExecute == null)
            {
                throw new ArgumentNullException("canExecute");
            }

            this.execute = execute;
            this.canExecute = canExecute;
        }

        /// <summary>
        /// コマンドを実行します。
        /// </summary>
        public void Execute(object parameter)
        {
            execute(parameter);
        }

        /// <summary>
        /// コマンドが実行可能な状態化どうか問い合わせます。
        /// </summary>
        /// <returns>実行可能な場合はtrue</returns>
        public bool CanExecute()
        {
            return canExecute();
        }

        /// <summary>
        /// ICommand.CanExecuteの明示的な実装。CanExecuteメソッドに処理を委譲する。
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute();
        }

        /// <summary>
        /// ICommand.Executeの明示的な実装。Executeメソッドに処理を委譲する。
        /// </summary>
        /// <param name="parameter"></param>
        void ICommand.Execute(object parameter)
        {
            Execute(parameter);
        }
    }
}
