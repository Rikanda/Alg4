using System;

namespace Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            MyTree.AddItem(8);
            MyTree.AddItem(4);
            MyTree.AddItem(5);
            MyTree.AddItem(3);
            MyTree.AddItem(6);
            MyTree.AddItem(10);
            MyTree.AddItem(9);
            MyTree.AddItem(11);
            MyTree.AddItem(7);
            MyTree.AddItem(2);

            var x = MyTree.GetNodeByValue(4);
            MyTree.GetParens(x);
            MyTree.RemoveItem(4);

        }
    }
}
