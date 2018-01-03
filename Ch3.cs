using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCProjects
{
    public class TreeNode
    {
        public TreeNode left{get;set;}
        public TreeNode right{get;set;}
        public int val{get;set;}

        public TreeNode(int v)
        {
            val = v;
            left = right = null;
        }
    }
    struct ResultType
    {
        public int maxDepth;
        public bool isBalanced;

        public int signlePath;
        public int maxPath;
    }
    class Ch3
    {
        /*
         Given a binary tree, determine if it is height-balanced.
         For this problem, a height-balanced binary tree is defined as a binary tree in which the depth of the two subtrees of every node never differ by more than 1.
         */
        public bool isBalanced(TreeNode root)
        {
            ResultType result=BlancedHelper(root);
            return result.isBalanced;
        }

        public ResultType BlancedHelper(TreeNode root)
        {
            ResultType result = new ResultType();
            if (root == null)
            {
                result.isBalanced = true;
                result.maxDepth = 0;
            }
            else
            {
                ResultType leftR = BlancedHelper(root.left);
                ResultType rightR = BlancedHelper(root.right);

                result.maxDepth = Math.Max(leftR.maxDepth, rightR.maxDepth) + 1;
                result.isBalanced = leftR.isBalanced && rightR.isBalanced && (Math.Abs(leftR.maxDepth - rightR.maxDepth) <= 1);
            }
            return result;
        }


        /*
            Given a binary tree, find the maximum path sum.

            The path may start and end at any node in the tree.
         */
        public int GetMaxPath(TreeNode root)
        {
            ResultType r = MaxPathHelper(root);
            return r.maxPath;
        }
        private ResultType MaxPathHelper(TreeNode root)
        {
            ResultType result = new ResultType();
            if (root == null)
            {
                result.maxPath = Int32.MinValue;
                result.signlePath = 0;
            }
            else
            {
                ResultType leftR = MaxPathHelper(root.left);
                ResultType rightR = MaxPathHelper(root.right);

                int singleP = Math.Max(leftR.signlePath, rightR.signlePath) + root.val;
                result.signlePath = Math.Max(singleP, 0);

                int maxP = leftR.signlePath + rightR.signlePath + root.val;
                result.maxPath = Math.Max(Math.Max(leftR.maxPath, rightR.maxPath), maxP);
            }
            return result;
        }

        /*Find lowest common ancester*/
        public TreeNode FindLCA(TreeNode root, TreeNode n1, TreeNode n2)
        {
            if (root == null || n1 == root || n2 == root)
                return root;
            TreeNode left = FindLCA(root.left, n1, n2);
            TreeNode right = FindLCA(root.right, n1, n2);

            if (left != null && right != null)
                return root;
            else if (left != null)
                return left;
            else if (right != null)
                return right;
            else
                return null;
        }

        /*show Binary tree by level order*/
        public ArrayList TranverseByLevel(TreeNode root)
        {
            ArrayList result = new ArrayList();
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                ArrayList level = new ArrayList();
                int size = q.Count;
                for (int i = 0; i < size; i++)
                { 
                    TreeNode node=q.Dequeue();
                    level.Add(node.val);
                    if (node.left != null)
                        q.Enqueue(node.left);
                    if (node.right != null)
                        q.Enqueue(node.right);
                    
                }
                result.Add(level);
            }
            return result;

        }

        public ArrayList SearchRange(TreeNode root, int s, int l)
        {
            ArrayList result = new ArrayList();
            if (root == null)
                return result;
            ArrayList left = SearchRange(root.left, s, l);
            ArrayList right = SearchRange(root.right, s, l);

            result.AddRange(left);
            if (root.val <= l && root.val >= s)
                result.Add(root.val);
            result.AddRange(right);
            return result;

        }

        private int GetMin(TreeNode root)
        {
            if (root == null)
                return Int32.MaxValue;
            TreeNode curt = root;
            while (curt.left != null)
                curt = curt.left;
            return curt.val;
        }

        public TreeNode DeleteNode(TreeNode root, int val)
        {
            if (root == null)
            {
                return root;
            }
            TreeNode curt = root;
            TreeNode parent = curt;
            while (curt.val != val)
            {
                
                parent = curt;
                if (curt.val < val)
                {
                    curt = curt.right;
                }
                else
                    curt = curt.left;
                if (curt == null)
                    return root;
            }

            if (curt.left == null && curt.right == null)
            {
                if (parent.left != null && parent.left == curt)
                    parent.left = null;
                else
                    parent.right = null;
            }
            else if (curt.left == null ^ curt.right == null)
            {
                if (parent.left != null && parent.left == curt)
                    parent.left = curt.left ?? curt.right;
                else
                    parent.right = curt.left ?? curt.right;
            }
            else
            {
                int new_val = GetMin(curt.right);
                curt.val = new_val;
                DeleteNode(curt.right, new_val);
            }
            return root;

        }
    }
}
