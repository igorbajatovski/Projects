// +++++++++++++++++++++++++++++++++++++++++++++ People ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

function parsePeople(people)
{
    return people.map( (elem) => { 
                                    return {
                                                id: elem.id,
                                                name: elem.name, 
                                                gender: elem.gender, 
                                                birth_year: elem.birth_year,
                                                height: elem.height,
                                                mass: elem.mass
                                            }
                                } );
}

// +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++