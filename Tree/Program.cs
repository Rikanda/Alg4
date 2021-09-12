using System;

namespace Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            MyTree testTree = new MyTree();

            testTree.AddItem(8);
            testTree.AddItem(4);
            testTree.AddItem(5);
            testTree.AddItem(3);
            testTree.AddItem(6);
            testTree.AddItem(10);
            testTree.AddItem(9);
            testTree.AddItem(11);
            testTree.AddItem(7);
            testTree.AddItem(2);

            var x = testTree.GetNodeByValue(4);
            testTree.GetParens(x);
            testTree.RemoveItem(4);



        }
    }
}
