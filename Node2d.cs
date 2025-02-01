using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class Node2d : Node2D
{
	Vector2I[] vector =
	{
		new (0,3),
		new (1,3),
		new (2,3),
		new (3,3),
		new (3,2),
		new (3,1),
		new (3,0),
		new (4,0),
		new (5,0),
		new (6,0),
		new (7,0),
		new (7,1),
		new (7,2),
		new (7,3),
		new (8,3),
		new (9,3),
		new (10,3),
		new (10,4),
		new (10,5),
		new (10,6),
		new (10,7),
		new (9,7),
		new (8,7),
		new (7,7),
		new (7,8),
		new (7,9),
		new (7,10),
		new (6,10),
		new (5,10),
		new (4,10),
		new (3,10),
		new (3,9),
		new (3,8),
		new (3,7),
		new (2,7),
		new (1,7),
		new (0,7),
		new (0,6),
		new (0,5),
		new (0,4),
	};
	Vector2I[] redVector =
	{
		new(1,5),
		new(2,5),
		new(3,5),
		new(4,5)
	};
	Vector2I[] yellowVector =
	{
		new(5,1),
		new(5,2),
		new(5,3),
		new(5,4)
	};
	Vector2I[] blueVector =
	{
		new(5,6),
		new(5,7),
		new(5,8),
		new(5,9)
	};
	Vector2I[] greenVector =
	{
		new(6,5),
		new(7,5),
		new(8,5),
		new(9,5)
	};
	Dictionary<Vector2I,Cell> Traps { get; set; }
	Dictionary<Vector2I,Cell> Walls { get; set; }
	Dictionary<Vector2I,Cell> CellsTokens { get; set; }
	[Export] Sprite2D sprite;
	[Export] Node2D[] tokens;
	[Export] TileMapLayer cell;
	Node2D[] Player0Tokens {get; set;}
	int[] tokens0pos = new[]{0,0,0,0};
	Node2D[] Player1Tokens {get; set;}
	int[] tokens1pos = new[]{0,0,0,0};
	Node2D[] Player2Tokens {get; set;}
	int[] tokens2pos = new[]{0,0,0,0};
	Node2D[] Player3Tokens {get; set;}
	int[] tokens3pos = new[]{0,0,0,0};
	int turno = 0;
	Game game;
	Random random;
	Control UI;
	Vector2I[] positionInitial =
	{
		new(0,0),
		new(1,0),
		new(0,1),
		new(1,1),
		new(9,0),
		new(10,0),
		new(9,1),
		new(10,1),
		new(0,9),
		new(1,9),
		new(0,10),
		new(1,10),
		new(9,9),
		new(10,9),
		new(9,10),
		new(10,10)
	};

	private void Dinos(string path, int i)
	{
		PackedScene packed = (PackedScene)GD.Load(path);

		Node2D redDino = packed.Instantiate<Node2D>();

		tokens[i].AddChild(redDino);

		Vector2 vector = cell.MapToLocal(positionInitial[i]);

		tokens[i].Position = cell.ToGlobal(vector);
	}
	private void CreateDinos()
	{
		for (int i = 0; i < 16; i++)
		{
			if (i < 4)
				Dinos("res://RedDino.tscn", i);

			else if (i < 8)
				Dinos("res://YellowDino.tscn", i);

			else if (i < 12)
				Dinos("res://BlueDino.tscn", i);

			else
				Dinos("res://GreenDino.tscn", i);
		}
	}
	public void UpdateDiceFace(int currentValue)
	{
		// Si usas Sprite, cambia la textura según el valor

		switch (currentValue)
		{
			case 1:
				sprite.Texture = GD.Load<Texture2D>("res://Images/1.png");
				break;
			case 2:
				sprite.Texture = GD.Load<Texture2D>("res://Images/2.png");
				break;
			case 3:
				sprite.Texture = GD.Load<Texture2D>("res://Images/3.png");
				break;
			case 4:
				sprite.Texture = GD.Load<Texture2D>("res://Images/4.png");
				break;
			case 5:
				sprite.Texture = GD.Load<Texture2D>("res://Images/5.png");
				break;
			case 6:
				sprite.Texture = GD.Load<Texture2D>("res://Images/6.png");
				break;
		}

	}
	private void _on_button_pressed()
	{
		game.Maze.Players[0].Tokens[0].UseAbility();
	}
	private void _on_button_2_pressed()
	{
		game.Maze.Players[0].Tokens[1].UseAbility();
	}
	private void _on_button_3_pressed()
	{
		game.Maze.Players[0].Tokens[2].UseAbility();
	}
	private void _on_button_4_pressed()
	{
		game.Maze.Players[0].Tokens[2].UseAbility();
	}
	private void _on_button_p_2_pressed()
	{
		game.Maze.Players[1].Tokens[0].UseAbility();
	}
	private void _on_button_2p_2_pressed()
	{
		game.Maze.Players[1].Tokens[1].UseAbility();
	}
	private void _on_button_2p_3_pressed()
	{
		game.Maze.Players[1].Tokens[2].UseAbility();
	}
	private void _on_button_2p_4_pressed()
	{
		game.Maze.Players[1].Tokens[3].UseAbility();
	}
	private void _on_button_p_3_pressed()
	{
		game.Maze.Players[2].Tokens[0].UseAbility();
	}
	private void _on_button_3p_2_pressed()
	{
		game.Maze.Players[2].Tokens[1].UseAbility();
	}

	private void _on_button_3p_3_pressed()
	{
		game.Maze.Players[2].Tokens[2].UseAbility();
	}

	private void _on_button_3p_4_pressed()
	{
		game.Maze.Players[2].Tokens[3].UseAbility();
	}

	private void _on_button_p_4_pressed()
	{
		game.Maze.Players[3].Tokens[0].UseAbility();
	}

	private void _on_button_4p_2_pressed()
	{
		game.Maze.Players[3].Tokens[1].UseAbility();
	}

	private void _on_button_4p_3_pressed()
	{
		game.Maze.Players[3].Tokens[2].UseAbility();
	}

	private void _on_button_4p_4_pressed()
	{
		game.Maze.Players[3].Tokens[3].UseAbility();
	}
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Traps = new Dictionary<Vector2I,Cell>();
		Walls = new Dictionary<Vector2I,Cell>();
		CellsTokens = new Dictionary<Vector2I,Cell>();

		// localizando las fichas
		Player0Tokens = new[]{
		GetNode<Node2D>("player0"),
		GetNode<Node2D>("player1"),
		GetNode<Node2D>("player2"),
		GetNode<Node2D>("player3")};

		Player1Tokens = new[]{
		GetNode<Node2D>("player4"),
		GetNode<Node2D>("player5"),
		GetNode<Node2D>("player6"),
		GetNode<Node2D>("player7")};

		Player2Tokens = new[]{
		GetNode<Node2D>("player8"),
		GetNode<Node2D>("player9"),
		GetNode<Node2D>("player10"),
		GetNode<Node2D>("player11")};

		Player3Tokens = new[]{
		GetNode<Node2D>("player12"),
		GetNode<Node2D>("player13"),
		GetNode<Node2D>("player14"),
		GetNode<Node2D>("player15")};

		random = new Random();
		game = new Game(new Board());
		UI = GetNode<Control>("Control");
		int numberOfPlayers = 4;

		game.StartGame(numberOfPlayers);

		for (int i = 0; i < game.Maze.Cells.Length; i++)
		{
			if (game.Maze.Cells[i] is Trap0 || game.Maze.Cells[i] is Trap1 || game.Maze.Cells[i] is Trap2)
			{
				Traps[vector[i]] = game.Maze.Cells[i];
			}

			if (game.Maze.Cells[i] is Wall)
			{
				Walls[vector[i]] = game.Maze.Cells[i];
			}

			if (game.Maze.Cells[i] is CellToken)
			{
				CellsTokens[vector[i]] = game.Maze.Cells[i];
			}
		}


		for (int i = 0; i < 40; i++)
		{

			if (game.Maze.Cells[i] is Trap)
			{
				cell.SetCell(vector[i], 0, new Vector2I(0, 0));
			}

			if (game.Maze.Cells[i] is Wall)
			{
				cell.SetCell(vector[i], 1, new Vector2I(1, 0));
			}

			else if (game.Maze.Cells[i] is CellToken)
			{
				cell.SetCell(vector[i], 3, new Vector2I(0, 0));
			}

			else
			{ }
		}

		CreateDinos();

		UpdateDiceFace(game.LastRoll);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void _on_control_on_roll_dice()
	{
		int face = random.Next(1, 7);
		UpdateDiceFace(face);
		game.LastRoll = face;
		MoveTokens(turno);
		turno ++;
		turno %= 4;
	}
	//IteratorOfTokens2D = player.GetEnumerator * player[x].Tokens.Count + player[x].Tokens.GetEnumerator
	private void MoveTokens(int IteratorOfTokens2D)
	{
		int token = 0;
		switch (IteratorOfTokens2D)
		{
			case 1:
				token = random.Next(0,4);
				if (tokens1pos[token] == 0)
					tokens1pos[token] = FindeTablePosition(new (7,1));
				else{
					tokens1pos[token]+= game.LastRoll;
					tokens1pos[token] %= vector.Length;
				}
				if (Traps.Keys.Contains<Vector2I>(vector[tokens1pos[token]]))
					Traps[vector[tokens1pos[token]]].ActivateEffect(game.Maze.Players[1].Tokens[token]);
				else if (Walls.Keys.Contains<Vector2I>(vector[tokens1pos[token]]))
					Walls[vector[tokens1pos[token]]].ActivateEffect(game.Maze.Players[1].Tokens[token]);
				else if (CellsTokens.Keys.Contains<Vector2I>(vector[tokens1pos[token]]))
					CellsTokens[vector[tokens1pos[token]]].ActivateEffect(game.Maze.Players[1].Tokens[token]);
				Player1Tokens[token].GlobalPosition = cell.MapToLocal(vector[tokens1pos[token]]);
				break;

			case 2:
				token = random.Next(0,4);
				if (tokens2pos[token] == 0)
					tokens2pos[token] = FindeTablePosition(new (3,9));
				else{
					tokens2pos[token]+= game.LastRoll;
					tokens2pos[token] %= vector.Length;
				}
				if (Traps.Keys.Contains<Vector2I>(vector[tokens2pos[token]]))
					Traps[vector[tokens2pos[token]]].ActivateEffect(game.Maze.Players[2].Tokens[token]);
				else if (Walls.Keys.Contains<Vector2I>(vector[tokens2pos[token]]))
					Walls[vector[tokens2pos[token]]].ActivateEffect(game.Maze.Players[2].Tokens[token]);
				else if (CellsTokens.Keys.Contains<Vector2I>(vector[tokens2pos[token]]))
					CellsTokens[vector[tokens2pos[token]]].ActivateEffect(game.Maze.Players[2].Tokens[token]);
				Player2Tokens[token].GlobalPosition = cell.MapToLocal(vector[tokens2pos[token]]);
				break;
			
			case 3:
				token = random.Next(0,4);
				if (tokens3pos[token] == 0)
					tokens3pos[token] = FindeTablePosition(new (9,7));
				else{
					tokens3pos[token]+= game.LastRoll;
					tokens3pos[token] %= vector.Length;
				}
				if (Traps.Keys.Contains<Vector2I>(vector[tokens3pos[token]]))
					Traps[vector[tokens3pos[token]]].ActivateEffect(game.Maze.Players[3].Tokens[token]);
				else if (Walls.Keys.Contains<Vector2I>(vector[tokens3pos[token]]))
					Walls[vector[tokens3pos[token]]].ActivateEffect(game.Maze.Players[3].Tokens[token]);
				else if (CellsTokens.Keys.Contains<Vector2I>(vector[tokens3pos[token]]))
					CellsTokens[vector[tokens3pos[token]]].ActivateEffect(game.Maze.Players[3].Tokens[token]);
				Player3Tokens[token].GlobalPosition = cell.MapToLocal(vector[tokens3pos[token]]);
				break;

			default:
				token = random.Next(0,4);
				if (tokens0pos[token] == 0)
					tokens0pos[token] = FindeTablePosition(new (1,3));
				else{
					tokens0pos[token]+= game.LastRoll;
					tokens0pos[token] %= vector.Length;
				}
				if (Traps.Keys.Contains<Vector2I>(vector[tokens0pos[token]]))
					Traps[vector[tokens0pos[token]]].ActivateEffect(game.Maze.Players[0].Tokens[token]);
				else if (Walls.Keys.Contains<Vector2I>(vector[tokens0pos[token]]))
					Walls[vector[tokens0pos[token]]].ActivateEffect(game.Maze.Players[0].Tokens[token]);
				else if (CellsTokens.Keys.Contains<Vector2I>(vector[tokens0pos[token]]))
					CellsTokens[vector[tokens0pos[token]]].ActivateEffect(game.Maze.Players[0].Tokens[token]);
				Player0Tokens[token].GlobalPosition = cell.MapToLocal(vector[tokens0pos[token]]);
				break;
		}
	
	}
	private int FindeTablePosition(Vector2 pos)
	{
		for (int i = 0; i < vector.Length; i++)
			if (vector[i].X == pos.X && vector[i].Y == pos.Y)
				return i;
		return -1;
	}
}
