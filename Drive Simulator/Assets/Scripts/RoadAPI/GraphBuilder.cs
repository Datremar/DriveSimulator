using System;
using Random = System.Random;

public class GraphBuilder
{
    private static Point currentPosition;
    private static Point newPosition;
    private static string[,] grid;
    private static int k, n;
    private static bool changeAxis = false;
    private static bool isVertical = true;
    private static Random rnd = new Random();

    public static string[,] BuildRoads()
    {
        n  = 40;
        k = 10;
        grid = new string[n, n];
        currentPosition = new Point((int)((n * 0.3) + rnd.Next(0, 2) * n * 0.4), (int)((n * 0.3) + rnd.Next(0, 2) * n * 0.4));
        newPosition = new Point();


        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                grid[i, j] = " - ";
            }
        }

        do
        {
            buildRoad((int)(rnd.Next(0, 2) * n * 0.4 + 5));
        } while (k != 0);

        return grid;
    }

    private static void buildRoad(int num_of_tiles)
    {
        grid[currentPosition.getY(), currentPosition.getX()] = " @ ";

        if (changeAxis)
        {
            isVertical = !isVertical;
            changeAxis = false;
        }

        if (isVertical)
        {
            buildDirection(rnd.Next(0, 2), num_of_tiles);
        }
        else
        {
            buildDirection(rnd.Next(0, 2) + 2, num_of_tiles);
        }

    }

    private static void buildDirection(int direction, int num_of_tiles)
    {

        switch (direction)
        {
            case 0:
                //up

                newPosition.setX(currentPosition.getX());
                newPosition.setY(currentPosition.getY());
                grid[newPosition.getY(), newPosition.getX()] = " @ ";

                for (int i = 1; i < num_of_tiles; i++)
                {
                    if (newPosition.getY() + 1 != n - 1)
                    {
                        if (isFree(newPosition.getX(), newPosition.getY() + 1))
                        {
                            newPosition.goUp();
                            grid[newPosition.getY(), newPosition.getX()] = " V ";
                            if (i != num_of_tiles - 1)
                            {
                                try
                                {
                                    grid[newPosition.getY(), newPosition.getX() - 1] = " . ";
                                }
                                catch (IndexOutOfRangeException ignored)
                                {
                                    ;
                                }
                                try
                                {
                                    grid[newPosition.getY(), newPosition.getX() + 1] = " . ";
                                }
                                catch (IndexOutOfRangeException ignored)
                                {
                                    ;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (rnd.Next(0, 2) == 1)
                        {
                            currentPosition.equalize(newPosition);
                            changeAxis = true;
                        }
                        break;
                    }
                }

                if (!changeAxis)
                {
                    if (rnd.Next(0, 2) == 1)
                    {
                        changeAxis = true;
                    }
                }


                if (rnd.Next(0, 2) == 1)
                {
                    currentPosition.equalize(newPosition);
                    k--;
                }

                break;
            case 1:
                //down

                newPosition.setX(currentPosition.getX());
                newPosition.setY(currentPosition.getY());
                grid[newPosition.getY(), newPosition.getX()] = " @ ";

                for (int i = 1; i < num_of_tiles; i++)
                {
                    if (newPosition.getY() - 1 != 0)
                    {
                        if (isFree(newPosition.getX(), newPosition.getY() - 1))
                        {
                            newPosition.goDown();
                            grid[newPosition.getY(), newPosition.getX()] = " V ";
                            if (i != num_of_tiles - 1)
                            {
                                try
                                {
                                    grid[newPosition.getY(), newPosition.getX() - 1] = " . ";
                                }
                                catch (IndexOutOfRangeException ignored)
                                {
                                    ;
                                }
                                try
                                {
                                    grid[newPosition.getY(), newPosition.getX() + 1] = " . ";
                                }
                                catch (IndexOutOfRangeException ignored)
                                {
                                    ;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (rnd.Next(0, 2) == 1)
                        {
                            currentPosition.equalize(newPosition);
                            changeAxis = true;
                        }
                        break;
                    }
                }

                if (!changeAxis)
                {
                    if (rnd.Next(0, 2) == 1)
                    {
                        changeAxis = true;
                    }
                }

                if (rnd.Next(0, 2) == 1)
                {
                    currentPosition.equalize(newPosition);
                    k--;
                }

                break;
            case 2:
                //right

                newPosition.setX(currentPosition.getX());
                newPosition.setY(currentPosition.getY());
                grid[newPosition.getY(), newPosition.getX()] = " @ ";

                for (int i = 1; i < num_of_tiles; i++)
                {
                    if (newPosition.getX() + 1 != n - 1)
                    {
                        if (isFree(newPosition.getX() + 1, newPosition.getY()))
                        {
                            newPosition.goRight();
                            grid[newPosition.getY(), newPosition.getX()] = " H ";
                            if (i != num_of_tiles - 1)
                            {
                                try
                                {
                                    grid[newPosition.getY() - 1, newPosition.getX()] = " . ";
                                }
                                catch (IndexOutOfRangeException ignored)
                                {
                                    ;
                                }
                                try
                                {
                                    grid[newPosition.getY() + 1, newPosition.getX()] = " . ";
                                }
                                catch (IndexOutOfRangeException ignored)
                                {
                                    ;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (rnd.Next(0, 2) == 1)
                        {
                            currentPosition.equalize(newPosition);
                            changeAxis = true;
                        }
                        break;
                    }
                }

                if (!changeAxis)
                {
                    if (rnd.Next(0, 2) == 1)
                    {
                        changeAxis = true;
                    }
                }

                if (rnd.Next(0, 2) == 1)
                {
                    currentPosition.equalize(newPosition);
                    k--;
                }

                break;
            case 3:
                //left

                newPosition.setX(currentPosition.getX());
                newPosition.setY(currentPosition.getY());
                grid[newPosition.getY(), newPosition.getX()] = " @ ";

                for (int i = 1; i < num_of_tiles; i++)
                {
                    if (newPosition.getX() - 1 != 0)
                    {
                        if (isFree(newPosition.getX() - 1, newPosition.getY()))
                        {
                            newPosition.goLeft();
                            grid[newPosition.getY(), newPosition.getX()] = " H ";
                            if (i != num_of_tiles - 1)
                            {
                                try
                                {
                                    grid[newPosition.getY() - 1, newPosition.getX()] = " . ";
                                }
                                catch (IndexOutOfRangeException ignored)
                                {
                                    ;
                                }
                                try
                                {
                                    grid[newPosition.getY() + 1, newPosition.getX()] = " . ";
                                }
                                catch (IndexOutOfRangeException ignored)
                                {
                                    ;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (rnd.Next(0, 2) == 1)
                        {
                            currentPosition.equalize(newPosition);
                            changeAxis = true;
                        }
                        break;
                    }
                }

                if (!changeAxis)
                {
                    if (rnd.Next(0, 2) == 1)
                    {
                        changeAxis = true;
                    }
                }

                if (rnd.Next(0, 2) == 1)
                {
                    currentPosition.equalize(newPosition);
                    k--;
                }

                break;
        }

    }

    private static bool isFree(int x, int y)
    {
        return grid[y, x] == " - ";
    }
}