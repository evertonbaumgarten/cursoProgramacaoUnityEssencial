
public class Turtle {
    
    public string name;
    public string state;
    public int speed;
    public int life;

	// Use this for initialization
	public Turtle (string name) {
        this.name = name;
	}
	
	public void walk()
    {
        state = "Walking";
    }

    public void jump()
    {
        state = "Jumping";
    }

    public void fly()
    {
        state = "Flyng";
    }

    public void rest()
    {
        state = "Resting";
    }

    public string ToString()
    {
       return name + " " + state;
    }
}
