public class Point {

    private int x;
    private int y;

    public Point()
    {
        this.x = 0;
        this.y = 0;
    }

    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public int getX()
    {
        return x;
    }

    public int getY()
    {
        return y;
    }

    public void setX(int x)
    {
        this.x = x;
    }

    public void setY(int y)
    {
        this.y = y;
    }

    public void goUp()
    {
        y++;
    }

    public void goDown()
    {
        y--;
    }

    public void goRight()
    {
        x++;
    }

    public void goLeft()
    {
        x--;
    }

    public void equalize(Point p)
    {
        this.x = p.getX();
        this.y = p.getY();
    }

    public string toString()
    {
        return (x + " " + y);
    }
}
