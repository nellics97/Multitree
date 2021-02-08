using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Multitree
{
    public class Node
    {

        public List<Node> Children { get; set; } = new List<Node>();

        public int Item { get; set; }

        [MaxLength(256)]
        public string NodeData { get; set; }

        public bool IsExpanded { get; set; }

        public SelectionState SelectionState { get; set; } = SelectionState.NotSelected;

        public Node()
        {

        }

        public Node(int item, string data, bool isExpanded)
        {
            Item = item;
            NodeData = data;
            IsExpanded = isExpanded;

        }

        public override string ToString()
        {
            string editedString = $"Node {Item}, Expanded: {IsExpanded}, SelectionState: {SelectionState}, Children: ";
            if (!Children.Any())
            {
                editedString += "no children";
            }
            else
            {
                foreach (var ch in Children)
                {
                    editedString += $"{ch.Item} ";
                }
                foreach (var ch in Children)
                {
                    editedString += $"\n{ch}";
                }
            }
            return editedString;
        }

        public void Expand()
        {
            this.IsExpanded = true;
            if (this.Children.Any())
            {
                foreach (var n in this.Children)
                {
                    n.Expand();
                }
            }
        }

        public void Collapse()
        {
            this.IsExpanded = false;
            if (this.Children.Any())
            {
                foreach (var n in this.Children)
                {
                    n.Collapse();
                }
            }
        }

        public void ChangeSelectedStateWithChildren(SelectionState state)
        {
            this.SelectionState = state;
            if (this.Children.Any())
            {
                foreach (var n in this.Children)
                {
                    n.ChangeSelectedStateWithChildren(state);
                }
            }
        }


        public void Select()
        {
            if (this.IsExpanded)
            {
                if (this.SelectionState == SelectionState.Selected || this.SelectionState == SelectionState.RecursivelySelected)
                {
                    this.SelectionState = SelectionState.NotSelected;
                }
                else
                {
                    this.SelectionState = SelectionState.Selected;
                }
            }
            else
            {
                if (this.SelectionState == SelectionState.Selected || this.SelectionState == SelectionState.RecursivelySelected)
                {
                    this.ChangeSelectedStateWithChildren(SelectionState.NotSelected);
                }
                else
                {
                    this.ChangeSelectedStateWithChildren(SelectionState.RecursivelySelected);
                }
            }
        }
    }
}
