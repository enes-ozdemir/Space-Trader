using System.Collections.Generic;
using UnityEngine;

public struct Customer
{
    public int dangerLevel;
    public bool isWanted;
    public Dictionary<Crime, int> crimeCountDictionary;
}

public class CustomerController : MonoBehaviour
{
    
    
    
} 

public enum CrimeType
{
    Theft,
    Assault,
    Arson,
    Kidnapping,
    Bribery,
    Burglary,
    Cyberbullying,
    DrugPossession,
    DrugTrafficking,
    Fraud,
    Extortion,
    Embezzlement,
    Forgery,
    Homicide,
    HateCrimes,
    IdentityTheft,
    TaxEvasion,
    MoneyLaundering,
    ToLove,
}

/**
Space piracy
Space smuggling
Space trespassing
Illegal space mining
Sabotage of a space station
Violation of space treaties
Illegal use of a space weapon
Illegal space colonization
Space terrorism
Unauthorized access to a space ship
These crime types could add more variety and depth to your space game, and help create a more realistic and engaging experience for players. You could also consider adding other types of crimes or offenses that are specific to your game setting or story. For example, if your space game takes place in a distant galaxy, you could add crimes such as worshiping forbidden gods or using forbidden technology. Alternatively, if your space game takes place in a dystopian future, you could add crimes such as rebellion against the government or illegal possession of books. The choice of crime types ultimately depends on the specific needs and goals of your game. I hope this helps! Let me know if you have any other questions.
*/