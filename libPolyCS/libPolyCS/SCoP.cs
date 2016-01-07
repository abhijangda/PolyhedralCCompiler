using System;
using System.Collections.Generic;

namespace libPolyCS
{
	public class LoopInfo
	{
		public string loopCounter { public get; private set; }
		public int loopStride { public get; private set; }
		public string loopRange { public get; private set; }
		public bool increasing { public get; private set; }
		public LoopInfo parent { public get; private set; }
		public List<LoopInfo> children {public get; private set;}

		public LoopInfo (string loopCounter, int loopStride, string loopRange,
			bool increasing, LoopInfo parent = null)
		{
			this.loopRange = loopRange;
			this.loopCounter = loopCounter;
			this.increasing = increasing;
			this.parent = parent;
			this.children = new List<LoopInfo> ();
		}
	}

	public class ArrayAccess
	{
		public string arrayName { public get; private set; }
		public string index { public get; private set; }

		public ArrayAccess (string arrayName, string index)
		{
			this.arrayName = arrayName;
			this.index = index;
		}
	}

	public abstract class MatrixEntry
	{
	}

	public class NumberMatrixEntry : MatrixEntry
	{
		public int value { public get; private set; }

	}

	public class IteratorMatrixEntry : MatrixEntry
	{
		public string value { public get; private set; }
	}

	public class Matrix
	{
		public List<List<MatrixEntry>> matrix { public get; private set; }
		public int rows { public get; private set; }
		public int cols { public get; private set; }


	}

	public class SchedulingFunction
	{
		public Matrix transMatrix { public get; private set; }
		public Matrix iterationVector { public get; private set; }
		public Matrix constantVector {public get; private set;}
	}

	public abstract class Statement
	{
		public SchedulingFunction schedFunc {public get; private set;}

	}

	public class IfStatement : Statement
	{
		public string op { public get; private set; }
		public string operand1 { public get; private set; }
		public string operand2 { public get; private set; }

		public IfStatement (string op, string operand1, string operand2)
		{
			this.op = op;
			this.operand1 = operand1;
			this.operand2 = operand2;
		}
	}

	public class ExpressionStatement : Statement
	{
		public List<ArrayAccess> arrayAccesses  { public get; private set; }

		public ExpressionStatement ()
		{
			arrayAccesses = new List<ArrayAccess> ();
		}
	}

	public class SCoP
	{
		public List<SCoP> children { public get; private set; }
		public List<Statement> statements { public get; private set; }

		public SCoP ()
		{
			children = new List<SCoP> ();
			statements = new List<Statement> ();
		}
	}
}

