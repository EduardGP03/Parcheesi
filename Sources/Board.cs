 // Elimina una ficha de la casilla
    public void RemoveToken(string token)
    {
        if (tokens.Contains(token))
        {
            tokens.Remove(token);
            Console.WriteLine($"Token de tipo '{token}' eliminada de la celda.");
        }
        else
        {
            Console.WriteLine($"No hay token de tipo '{token}' en esta celda para eliminar.");
        }
    }

       // Agrega una ficha a la casilla
    public void AddToken(Token token)
    {
        if (tokens.Count > 0)
        {
            // Verifica si la nueva ficha es de un tipo diferente
            if (tokens[0].Type != token.Type)
            {
                tokens.Clear();
            }
            tokens.Add(token); 
            return;
        }

        tokens.Add(token);
        Console.WriteLine($"Token de tipo '{token}' añadida a la celda.");
        return;
    }