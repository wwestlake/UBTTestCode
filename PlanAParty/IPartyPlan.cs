using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanAParty
{
    /// <summary>
    /// When implemented this interface must return that information according to the 
    /// supplied data following these business rules:
    /// 
    /// There will be 5 adult organiers
    /// 
    /// 1. TotalParticipants:  Children under 5 must have an adult accompany them.
    /// 2. TotalBaloons:  There must be sufficient baloons of each color so that every child 
    ///                   gets a baloon of their favortite color
    /// 3. TotalIceCream:  There must be sufficient icecream so that each child gets 1 scoop 
    ///                    of their favorite ice cream.
    /// 4. TotalSandwitches: There musst be suffient sandwitches such that each child gets 1 sandwitch
    /// 5. Coffee:  There must be suffience coffee for all adults present including the organizers
    /// 6. Boys get a blue party hat
    ///    girls get a pink party hat
    ///    organizers get a green party hat
    ///    parents get a yellow party hat
    /// </summary>
    public interface IPartyPlan
    {

        /// <summary>
        /// Includes children, adults, and organizers
        /// </summary>
        int TotalParticipants { get; }

        /// <summary>
        /// The total number of children
        /// </summary>
        int TotalChildren { get; }

        /// <summary>
        /// The total number of adults including organizers
        /// </summary>
        int TotalAdults { get; }

        /// <summary>
        /// Baloon count by color
        /// </summary>
        /// <param name="color">The color of the baloon</param>
        /// <returns>The number of required baloons</returns>
        int TotalBaloonCount(Colors color);

        /// <summary>
        /// IdeCream count by flavor
        /// </summary>
        /// <param name="iceCream">The ice cream flavod</param>
        /// <returns>The total number of scoops</returns>
        int TotalIceCreamScoops(IceCream iceCream);


        /// <summary>
        /// The total number of sanwitches
        /// </summary>
        int TotalSandwitches { get; }

        /// <summary>
        /// The total number of cups of coffee
        /// </summary>
        int Coffee { get; }

        int Hats(Colors color);

        int TotalHats { get; }

    }
}
