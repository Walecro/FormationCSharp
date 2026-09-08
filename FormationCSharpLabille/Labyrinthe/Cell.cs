namespace Exercices.Labyrinthe
{
	public struct Cell
	{
		public enum State
		{
			BEGIN
				, CELL
				, END
		}

		// 0 : Haut, 1 : bas, 2 : gauche, 3 : droite
		public bool[] Walls { get; set; }

		public bool IsVisited { get; set; }

		public State state;
	}
}
