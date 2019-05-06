let price =  {
    fuel: 50,
    repair: 60,
    crew: 80
}

let ships = [
    new Ship("StarFighter", 3, 380, 500, 0.5, "images/StarFighter.png"),
    new Ship("Crushinator", 5, 540, 400, 0.2, "images/Crushinator.png"),
    new Ship("Scouter", 1, 300, 300, 0.9, "images/Scouter.png")
]


let planets = [
    new Planet("Rubicon9", 300000, 2000000, 4, 2, "images/Rubicon9.png"),
    new Planet("R7", 120000, 4000000, 7, 3, "images/R7.png"),
    new Planet("Magmus", 500000, 10000000, 6, 1, "images/Magmus.png"),
    new Planet("Dextriaey", 50000, 500000, 9, 3, "images/Dextriaey.png"),
    new Planet("B18-1", 250000, 4000000, 12, 2, "images/B18-1.png")
]

let events = [
    new SpaceEvent("Fuel Leak", "Due to low maintenance of the ship, the fuel tank leaked. The leak was patched, but we lost some fuel.", 0, -50, 0 ),
    new SpaceEvent("Pirates!", "Space pirates attacked the ship! We escaped, but our hull took some damage!", 0, -20, -150 ),
    new SpaceEvent("Unknown substance", "An unknown substance was found on the cargo ship. A crew member touched it and died on the spot.", -1, 0, 0 ),
    new SpaceEvent("Asteroid field", "We entered an asteroid field. It was hard, but our captain managed to go out of it.", 0, -30, -100 ),
    new SpaceEvent("Fire on deck", "The main system overheated and fire broke from one of the panels. The crew quickly extinguished it.", 0, 0, -70 ),
    new SpaceEvent("Bad stop", "You stop at a nearby station for a pit-stop. They give you repair supplies.", 0, -50, +50 ),
    new SpaceEvent("Captains Birthday", "It's the captain's birthday. Everybody got drunk. Nobody remembers what happened the last 12 hours.", -1, -60, -100 ),
    new SpaceEvent("Space Shark", "Your ship is attacked by a space shark. After killing it, you watch a tutorial on how to turn shark blood in to fuel.", 0, +80, -120 ),
    new SpaceEvent("Alien in need", "An alien is stranded on it's broken ship. It took some time and effort but you save him and board him on your ship.", 1, -50, -50 ),
    new SpaceEvent("Hail the federation", "A federation cruiser hails you. They help you with supplies and fuel.", 0, +100, +100 ),
    new SpaceEvent("Destroyed Transport Ship", "You encounter a destroyed transport ship. It's dangerous, but you try salvaging its fuel tank.", 0, +150, -80 ),
    new SpaceEvent("Angry Spider", "An angry spider appears on the deck. The captain stomps on it. Everything is fine", 0, 0, 0 )
];

let selectedShip = null;

function copyArray(array)
{
    let newArray = [];
    for (const item of array) {
        let newObject = Object.assign({}, item);
        Object.setPrototypeOf(newObject, Object.getPrototypeOf(item));
        newArray.push(newObject);
    }
    return newArray;
}

displayShips(copyArray(ships));
