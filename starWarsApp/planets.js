// +++++++++++++++++++++++++++++++++++++++++++++++++++++++ Planets +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

function parsePlanets(planets)
{
    return planets.map( (elem) => { 
                                        return {
                                                    id: elem.id,
                                                    name: elem.name, 
                                                    diameter: elem.diameter, 
                                                    climate: elem.climate,
                                                    terrain: elem.terrain,
                                                    rotation_period: elem.rotation_period,
                                                    population: elem.population
                                                }
                                    } );
}

// +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++