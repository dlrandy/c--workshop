using System;
using System.Collections.Generic;

namespace Exer04_03{
    class UndoStack
    {
        private readonly Stack<Action> _undoStack = new Stack<Action>();

        public void Do(Action action){
            _undoStack.Push(action);
        }

        public void Undo(){
            if (_undoStack.Count > 0)
            {
                var undo = _undoStack.Pop();
                undo?.Invoke();
            }
        }


    }

    class TextEditor
    {
        private readonly UndoStack _undoStack;
        public TextEditor(UndoStack undoStack){
            _undoStack = undoStack;
        }

        public string Text{get;private set;}

        public void EditText(string newText){
            var previousText = Text;
            _undoStack.Do(()=>{
                Text = previousText;
                Console.Write($"Undo:'{newText}'".PadRight(40));
                Console.WriteLine($"Text='{Text}'");
            });

            Text += newText;
            Console.Write($"Edit:'{newText}'".PadRight(40));
            Console.WriteLine($"Text='{Text}'");
        }
    }
    class Program
    {
        public static void Main(){
            var undoStack = new UndoStack();
            var editor = new TextEditor(undoStack);

            editor.EditText("one Day, ");
            editor.EditText("in a ");
            editor.EditText("city ");
            editor.EditText("near by ");

            undoStack.Undo();
            undoStack.Undo();
            editor.EditText("land ");
            editor.EditText("far far away");

            Console.ReadLine();
        }
    }
}