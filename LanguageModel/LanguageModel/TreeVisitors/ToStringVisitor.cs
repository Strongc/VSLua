﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageService.LanguageModel.TreeVisitors
{
    class ToStringVisitor : INodeVisitor
    {
        public IndentingTextWriter indentingWriter;

        public ToStringVisitor()
        {
            indentingWriter = IndentingTextWriter.Get(new StringWriter());
        }

        public void Visit(SimpleExpression node)
        {
            indentingWriter.WriteLine("Expression:");
            using (indentingWriter.Indent())
            {
                Visit(node.ExpressionValue);
            }
        }

        public void Visit(UnaryOperatorExpression node)
        {
            indentingWriter.WriteLine("Expression");
            using (indentingWriter.Indent())
            {
                Visit(node.UnaryOperator);
                Visit(node.Exp);
            }
        }

        public void Visit(ElseIfBlockNode node)
        {
            indentingWriter.WriteLine("ElseIfBlock: ");
            using (indentingWriter.Indent())
            {
                Visit(node.Exp);
                Visit(node.Block);
            }
        }

        public void Visit(TableConstructorExp node)
        {
            indentingWriter.WriteLine("TableConstructor");
            using (indentingWriter.Indent())
            {
                Visit(node.FieldList);
            }
        }

        public void Visit(BinaryOperatorExpression node)
        {
            indentingWriter.WriteLine("Expression");
            using (indentingWriter.Indent())
            {
                Visit(node.Exp1);
                Visit(node.BinaryOperator);
                Visit(node.Exp2);
            }
        }

        public void Visit(IfStatementNode node)
        {
            indentingWriter.WriteLine("IfNode");
            using (indentingWriter.Indent())
            {
                Visit(node.Exp);
                Visit(node.IfBlock);
            }

            if (node.ElseIfList != null)
            {
                foreach (var block in node.ElseIfList)
                {
                    using (indentingWriter.Indent())
                    {
                        if (block != null)
                        {
                            Visit(block);
                        }
                        else
                        {
                            indentingWriter.WriteLine("null"); //TODO: validate will ever reach here?
                        }
                    }
                }
            }

            if (node.ElseBlock != null)
            {
                using (indentingWriter.Indent())
                {
                    Visit(node.ElseBlock);
                }
            }
        }

        public void Visit(BlockNode node)
        {
            indentingWriter.WriteLine("Block");
            foreach (var child in node.Statements)
            {
                using (indentingWriter.Indent())
                {
                    Visit(child);
                }
            }

            if (node.ReturnStatement != null)
            {
                using (indentingWriter.Indent())
                {
                    Visit(node.ReturnStatement);
                }
            }
        }

        public void Visit(ChunkNode node)
        {
            indentingWriter.WriteLine("ChunkNode");
            using (indentingWriter.Indent())
            {
                Visit(node.ProgramBlock);
                Visit(node.EndOfFile);
            }
        }

        internal override void Visit(Token token)
        {
            indentingWriter.WriteLine(token.ToString());
        }

        public void Visit(ElseBlockNode node)
        {
            indentingWriter.WriteLine("ElseBlock");
            using (indentingWriter.Indent())
            {
                Visit(node.Block);
            }
        }

        #region Not Implemented Visit Methods
        public void Visit(ExpressionNode node)
        {
            if (node is SimpleExpression)
                Visit(node as SimpleExpression);
            else if (node is BinaryOperatorExpression)
                Visit(node as BinaryOperatorExpression);
            else if (node is UnaryOperatorExpression)
                Visit(node as UnaryOperatorExpression);
            else if (node is TableConstructorExp)
                Visit(node as TableConstructorExp);
            else if (node is FunctionDef)
                Visit(node as FunctionDef);
            else if (node is Var)
                Visit(node as Var);
            else if (node is FunctionCallExp)
                Visit(node as FunctionCallExp);
            else if (node is ParenPrefixExp)
                Visit(node as ParenPrefixExp);
            else
                throw new ArgumentException();
        }

        public void Visit(ExpList node)
        {
            throw new NotImplementedException();
        }

        public void Visit(BreakStatementNode breakStatementNode)
        {
            throw new NotImplementedException();
        }

        public void Visit(NameDotPair nameDotPair)
        {
            throw new NotImplementedException();
        }

        public void Visit(FuncNameNode funcNameNode)
        {
            throw new NotImplementedException();
        }

        public void Visit(StringArg stringArg)
        {
            throw new NotImplementedException();
        }

        public void Visit(SemiColonStatementNode node)
        {
            indentingWriter.WriteLine("SemiColonStatement\t ;");
        }

        public void Visit(AssignmentField node)
        {
            throw new NotImplementedException();
        }

        public void Visit(TableConstructorNode node)
        {
            throw new NotImplementedException();
        }

        public void Visit(FuncBodyNode node)
        {
            throw new NotImplementedException();
        }

        public void Visit(ExpField node)
        {
            throw new NotImplementedException();
        }

        public void Visit(BracketField node)
        {
            throw new NotImplementedException();
        }

        public void Visit(ParList node)
        {
            throw new NotImplementedException();
        }

        public void Visit(NameList node)
        {
            throw new NotImplementedException();
        }

        public void Visit(DotVar node)
        {
            throw new NotImplementedException();
        }

        public void Visit(NameVar node)
        {
            throw new NotImplementedException();
        }

        public void Visit(FunctionCallExp node)
        {
            throw new NotImplementedException();
        }

        public void Visit(ReturnStatementNode node)
        {
            throw new NotImplementedException();
        }

        public void Visit(FunctionDef node)
        {
            throw new NotImplementedException();
        }

        public void Visit(FieldNode node)
        {
            throw new NotImplementedException();
        }

        public void Visit(ParenPrefixExp node)
        {
            throw new NotImplementedException();
        }

        public void Visit(SquareBracketVar node)
        {
            throw new NotImplementedException();
        }

        public void Visit(FieldList node)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
