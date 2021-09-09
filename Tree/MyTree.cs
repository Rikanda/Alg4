using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class MyTree // двоичное дерево поиска
    {
        public static  TreeNode startRoot = null; // корень (основание) дерева
        public static void AddItem(int value)
        {
            var newNode = new TreeNode { Value = value };
            if(startRoot == null) // если дерево пустое, создаем корень
            {
                startRoot = newNode;
                startRoot.LeftChild = null;
                startRoot.RightChild = null;
                Console.WriteLine("Создано дерево с корневым значением " + startRoot.Value);
                return;
            }

            
                TreeNode r = startRoot;
            
            while (r!= null)
                {
                    if (value > r.Value) // если значение больше, идем в правую ветку
                    {
                    
                    if (r.RightChild != null)
                        {
                            r = r.RightChild; // если не пусто, переходим к дочернему правому узлу и продолжаем проверку
                            continue;
                        }
                        else
                        {
                            r.RightChild = newNode; // иначе присваиваем узел правому потомку

                            Console.WriteLine(r.RightChild.Value + " значение присвоено как правое, родитель = " + r.Value);

                            return;
                        }
                    }
                    else if (value < r.Value) // если значение меньше, идем в левую ветку
                    {
                   
                    if (r.LeftChild != null)
                        {
                            r = r.LeftChild; // если не пусто, переходим к дочернему левому узлу и продолжаем проверку
                            continue;

                        }
                        else
                        {
                       
                        r.LeftChild = newNode; // иначе присваиваем узел левому потомку

                            Console.WriteLine(r.LeftChild.Value + " значение присвоено как левое, родитель = " + r.Value);
                            return;
                        }
                    }
                    else
                    {
                        throw new Exception("Wrong tree state"); // дерево построено неправильно
                    }
                

            
            }
        }

        


        public static TreeNode GetNodeByValue(int value)
        {
            TreeNode r = startRoot;
            while (r != null) // выполняем обход дерева
            {
                if (r.Value == value) // если значение совпало с искомым, возвращаем узел
                {
                    Console.WriteLine("Узел со значением " + r.Value +" найден");
                    return r;

                }

              if (value > r.Value) // если искомое больше узла, идем в правую ветку
                {
                    r = r.RightChild;
                    continue;
                }

              if (value < r.Value) // если искомое меньше узла, идем в левую ветку
                {
                    r = r.LeftChild; 
                    continue;
                }
            }

            return null; // если ничего не нашли, возвращаем null
        }

        public TreeNode GetRoot() // не поняла, какой узел должен возвращать этот метод - т.к. нет входящего аргумента
        {
            throw new NotImplementedException();
        }

        public void PrintTree() // не реализовала
        {
            throw new NotImplementedException();
        }

      

        public static TreeNode GetParens(TreeNode T)   // добавила свой метод, который возвращает ноду "родителя" по заданной ноде потомка
        {
            if (T.Value == startRoot.Value)
            {
                return null; // у начальной ноды нет родителя
            }

            else
            {
                var r = startRoot;

                while (r != T) // выполняем обход дерева
                {
                    if (T.Value > r.Value) // если значение больше, ищем среди правых потомков
                    {
                        if (r.RightChild == T)
                        {
                            Console.WriteLine("Родитель найден, его значение = " + r.Value);
                            return r;
                        }
                        else
                        {
                            r = r.RightChild;
                            continue;
                        }
                    }

                    if (T.Value < r.Value) // если значение меньше, ищем среди левых потомков
                    {
                        if (r.LeftChild == T)
                        {
                            Console.WriteLine("Родитель найден, его значение = " + r.Value);
                            return r;
                        }
                        else
                        {
                            r = r.LeftChild;
                            continue;
                        }
                    }

                }
            }

            return null; // если ничего не нашли

        }


        public static void RemoveItem(int value)
        {
            

            TreeNode rem = GetNodeByValue(value);
            
            TreeNode p = GetParens(rem);

            

            // если у элемента нет потомков, то обнуляем ссылку на него у родителя

            if (rem.RightChild == null && rem.LeftChild == null)
            {  // если у нас только одна начальная нода без потомков обнуляем поле стартовой ноды
                if(p==null)
                {
                    startRoot = null;
                    return;
                }

                if (p.LeftChild == rem) // если нода не начальная, убираем ссылку на нее из родителя
                {
                    p.LeftChild = null;
                    return;
                }
                else
                {
                    p.RightChild = null;
                    return;
                }
            }
           // если есть потомки при удалении узла, для сохранения структуры двоичного дерева поиска,
           // вместо удаляемого надо ставить либо наибольшее значение из левой ветки, либо наименьшее из правой,
           // у этих крайних может быть только один потомок, которого нужно перезаписать на их место (правый у наименьшей и левый у наибольшей)
           // и перезаписать потомков из удаляемой ноды в подставляемую ноду

            if(rem.RightChild!=null) // если у ноды есть правая ветка
            {
                TreeNode min = rem.RightChild; // минимальное значение правой ветки будет ее крайним левым элементом
                while(min.LeftChild != null)
                {
                    min = min.LeftChild; // ищем подставляемую ноду
                 
                }
                
                TreeNode pmin = GetParens(min);

               

                if (pmin == rem) // если подставляемая нода является прямым потомком удаляемой
                {
                    min.LeftChild = rem.LeftChild; // перепривязываем левую ветку удаляемой ноды, правую оставляем 
                }

                else
                {
                    // если подставляемая нода не является прямым потомком удаляемой

                    if (min.RightChild == null) // если правого потомка у подставляемой ноды нет
                    {
                        pmin.LeftChild = null; // убираем ссылку из родителя подставляемой ноды на нее
                    }
                    else
                    {
                        pmin.LeftChild = min.RightChild; // или замещаем подставляемую ноду ее правым потомком , если он есть
                    }

                    min.LeftChild = rem.LeftChild; // перезаписываем ссылки потомков из удаляемой ноды в подставляемую
                    min.RightChild = rem.RightChild;
                }

                if (p!=null) // если узел не первый, переопределяем ссылку родителя вместо удаляемой ноды на подставляемую
                {
                    if (p.LeftChild == rem)
                    {
                        p.LeftChild = min;
                    }
                    else
                    {
                        p.RightChild = min;
                    }
                }

                Console.WriteLine("Удаляем " + rem.Value + " и вместо него подставляем " + min.Value + " Потомки нового значения: левый = "+ min.LeftChild.Value+ " правый= "+ min.RightChild.Value);
                return;
            }

            else // если есть только левая ветка - действия симметричные 
            {
                TreeNode max = rem.LeftChild;
                while(max.RightChild !=null)
                {
                    max = max.RightChild;
                }

                TreeNode pmax = GetParens(max);

                if (max.LeftChild == null)
                {
                    pmax.RightChild = null;
                }
                else
                {
                    pmax.RightChild = max.LeftChild;
                }

                if (pmax == rem) // если подставляемая нода является прямым потомком удаляемой
                {
                    max.RightChild = rem.RightChild; 
                }

                else
                {
                    // если подставляемая нода не является прямым потомком удаляемой

                    if (max.LeftChild == null)
                    {
                        pmax.RightChild = null; 
                    }
                    else
                    {
                        pmax.RightChild = max.LeftChild; 
                    }

                    max.RightChild = rem.RightChild; 
                    max.LeftChild = rem.LeftChild;
                }


                if (p != null) 
                {
                    if (p.LeftChild == rem)
                    {
                        p.LeftChild = max;
                    }
                    else
                    {
                        p.RightChild = max;
                    }
                }

                Console.WriteLine("Удаляем " + rem.Value + " и вместо него подставляем " + max.Value + " Потомки нового значения: левый = " + max.LeftChild.Value + " правый= " + max.RightChild.Value);

                return;

            }
        }
    }

    public interface ITree
    {
        TreeNode GetRoot();
        void AddItem(int value); // добавить узел
        void RemoveItem(int value); // удалить узел по значению
        TreeNode GetNodeByValue(int value); //получить узел дерева по значению
        void PrintTree(); //вывести дерево в консоль
    }
}
