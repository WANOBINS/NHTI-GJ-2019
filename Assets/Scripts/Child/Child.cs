using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child : MonoBehaviour
{
    public string name;
    public float speed;
    public Vector3 destination;
    public bool immortal;


    // Start is called before the first frame update
    void Start()
    {
        ChildName childName = new ChildName();
        name = childName.Name();
        destination = endPoint();
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, destination, step);
        if(!immortal && transform.position.z < 1)
        {
            immortal = true;
            Debug.Log(name + " has made it to the bouncey castle you pathetic magician!");
        }
    }

    public Vector3 endPoint()
    {
        float x = Random.Range(-15f, 15f);
        Vector3 dest = new Vector3(x, 1.5f, -2f);
        return dest;
    }

}

public class ChildName
{

    public string[] names = new string[200] 
    {
    "Liam",
    "Emma",
    "Noah",
    "Olivi",
    "William",
    "Ava",
    "James",
    "Isabell",
    "Oliver",
    "Sophia",
    "Benjamin",
    "Charlotte",
    "Elijah",
    "Mia",
    "Lucas",
    "Amelia",
    "Mason",
    "Harper",
    "Logan",
    "Evelyn",
    "Alexander",
    "Abigail",
    "Ethan",
    "Emily",
    "Jacob",
    "Elizabeth",
    "Michael",
    "Mila",
    "Daniel",
    "Ella",
    "Henry",
    "Avery",
    "Jackson",
    "Sofia",
    "Sebastian",
    "Camila",
    "Aiden",
    "Aria",
    "Matthew",
    "Scarlett",
    "Samuel",
    "Victoria",
    "David",
    "Madison",
    "Joseph",
    "Luna",
    "Carter",
    "Grace",
    "Owen",
    "Chloe",
    "Wyatt",
    "Penelope",
    "John",
    "Layla",
    "Jack",
    "Riley",
    "Luke",
    "Zoey",
    "Jayden",
    "Nora",
    "Dylan",
    "Lily",
    "Grayson",
    "Eleanor",
    "Levi",
    "Hannah",
    "Isaac",
    "Lillian",
    "Gabriel",
    "Addison",
    "Julian",
    "Aubrey",
    "Mateo",
    "Ellie",
    "Anthony",
    "Stella",
    "Jaxon",
    "Natalie",
    "Lincoln",
    "Zoe",
    "Joshua",
    "Leah",
    "Christopher",
    "Hazel",
    "Andrew",
    "Violet",
    "Theodore",
    "Aurora",
    "Caleb",
    "Savannah",
    "Ryan",
    "Audrey",
    "Asher",
    "Brooklyn",
    "Nathan",
    "Bella",
    "Thomas",
    "Claire",
    "Leo",
    "Skylar",
    "Isaiah",
    "Lucy",
    "Charles",
    "Paisley",
    "Josiah",
    "Everly",
    "Hudson",
    "Anna",
    "Christian",
    "Caroline",
    "Hunter",
    "Nova",
    "Connor",
    "Genesis",
    "Eli",
    "Emilia",
    "Ezra",
    "Kennedy",
    "Aaron",
    "Samantha",
    "Landon",
    "Maya",
    "Adrian",
    "Willow",
    "Jonathan",
    "Kinsley",
    "Nolan",
    "Naomi",
    "Jeremiah",
    "Aaliyah",
    "Easton",
    "Elena",
    "Elias",
    "Sarah",
    "Colton",
    "Ariana",
    "Cameron",
    "Allison",
    "Carson",
    "Gabriella",
    "Robert",
    "Alice",
    "Angel",
    "Madelyn",
    "Maverick",
    "Cora",
    "Nicholas",
    "Ruby",
    "Dominic",
    "Eva",
    "Jaxson",
    "Serenity",
    "Greyson",
    "Autumn",
    "Adam",
    "Adeline",
    "Ian",
    "Hailey",
    "Austin",
    "Gianna",
    "Santiago",
    "Valentina",
    "Jordan",
    "Isla",
    "Cooper",
    "Eliana",
    "Brayden",
    "Quinn",
    "Roman",
    "Nevaeh",
    "Evan",
    "Ivy",
    "Ezekiel",
    "Sadie",
    "Xavier",
    "Piper",
    "Jose",
    "Lydia",
    "Jace",
    "Alexa",
    "Jameson",
    "Josephine",
    "Leonardo",
    "Emery",
    "Bryson",
    "Julia",
    "Axel",
    "Delilah",
    "Everett",
    "Arianna",
    "Parker",
    "Vivian",
    "Kayden",
    "Kaylee",
    "Miles",
    "Sophie",
    "Sawyer",
    "Brielle",
    "Jason",
    "Madeline"
    };

    public string Name()
    {
        int nameIndex = Random.Range(0, 200);

        return names[nameIndex];
    }
}