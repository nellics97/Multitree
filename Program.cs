using System;
using System.Collections.Generic;
using System.Linq;

namespace Multitree
{
    class Program
    {

        public static Node BuildTree()
        {
            var root = new Node
            {
                Children = new List<Node>() 
                { 
                    new Node
                    {
                        Item = 2,
                        IsExpanded = true,
                       
                    },
                    new Node
                    {
                        Item = 3,
                        IsExpanded = true,
                        
                    },
                    new Node
                    {
                        Item = 4,
                        IsExpanded = true,
                        
                    }
                },
                Item = 1,
                IsExpanded = true,
  

            };

            root.Children[0].Children.Add(
                new Node
                {
                    Item = 5,
                    IsExpanded = false,
                  
                });

            root.Children[0].Children.Add(
                new Node
                {
                    Item = 6,
                    IsExpanded = false,
                  
                });

            root.Children[1].Children.Add(
                new Node
                {
                    Item = 7,
                    IsExpanded = false,
                   
                });

            root.Children[2].Children.Add(
                new Node
                {
                    Item = 8,
                    IsExpanded = false,
                    
                });

            return root;


        }
        static void Main(string[] args)
        {

            var root = BuildTree();
            Console.WriteLine("Initial state");
            Console.WriteLine(root.ToString());

            root.Collapse();
            Console.WriteLine("\n\nAfter collapsing root:");
            Console.WriteLine(root.ToString());

            root.Select();
            Console.WriteLine("\n\nAfter selecting root:");
            Console.WriteLine(root.ToString());

            root.Children[0].Expand();
            Console.WriteLine("\n\nAfter expanding node 2:");
            Console.WriteLine(root.ToString());

            root.Children[0].Collapse();
            Console.WriteLine("\n\nAfter collapsing node 2:");
            Console.WriteLine(root.ToString());

            root.Children[0].Select();
            Console.WriteLine("\n\nAfter selecting node 2:");
            Console.WriteLine(root.ToString());



        }


    }
}
