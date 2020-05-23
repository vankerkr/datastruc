using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BinarySearchTreeAss6
{
    class TreeNode
    {
        private int data;
        public int Data
        {
            get { return data; }
        }

        private TreeNode rightNode;

        public TreeNode RightNode
        {
            get { return rightNode; }
            set { rightNode = value; }
        }

        private TreeNode leftNode;

        public TreeNode LeftNode
        {
            get { return leftNode; }
            set { leftNode = value; }
        }

        private bool isDeleted;

        public bool IsDeleted
        {
            get { return isDeleted;  }
        }

        //Constructor
        public TreeNode(int value)
        {
            data = value;
        }

        //set soft delete
        public void Delete()
        {
            isDeleted = true;
        }

        public TreeNode Find(int value)
        {
            //this node is the starting current node
            TreeNode currentNode = this;

            //loop through this node and children
            while (currentNode != null)
            {
                //if current node data is equal to value pased, return it
                if (value == currentNode.data && isDeleted == false) //checks soft delete
                {
                    return currentNode;
                }
                else if (value > currentNode.data)// checks if value passed is greater than curent, then goes to the right child
                {
                    currentNode = currentNode.rightNode;
                }
                else// if passed data is less, go the left child node
                {
                    currentNode = currentNode.leftNode;
                }
            }
            //Node couldnt be found
            return null;
        }

        public TreeNode FindRecursive(int value)
        {
            //value passed in matches nodes data return the node
            if (value == data && isDeleted == false)
            {
                return this;
            }
            else if (value < data && leftNode != null)//if the val passed is less than the current data then go to left child
            {
                return leftNode.FindRecursive(value);
            }
            else if (rightNode != null) //if its greater then go to the right child
            {
                return rightNode.FindRecursive(value);
            }
            else
            {
                return null;
            }

        }

        //recursively calls insert down the tree until it find an open spot
        public void Insert(int value)
        {
            //if the value passed in is greater or equal to the data then insert to right node
            if (value >= data)
            {   //if right child node is null create one
                if (rightNode == null)
                {
                    rightNode = new TreeNode(value);
                }
                else
                {//if right node is not null recursivly call insert on the right node
                    rightNode.Insert(value);
                }
            }
            else
            {//if the value passed in is less than the data then insert to left node
                if (leftNode == null)
                {//if the leftnode is null then create a new node
                    leftNode = new TreeNode(value);
                }
                else
                {//if the left node is not null then recursively call insert on the left node
                    leftNode.Insert(value);
                }
            }
        }

        //Number return in ascending order
        //Left->Root->Right Nodes recursively of each subtree 
        public void InOrderTraversal()
        {
            //first go to left child its children will be null so we print its data
            if (leftNode != null)
                leftNode.InOrderTraversal();
            //Then we print the root node 
            Console.Write(data + " ");

            //Then we go to the right node which will print itself as both its children are null
            if (rightNode != null)
                rightNode.InOrderTraversal();
        }

        










    }
}
