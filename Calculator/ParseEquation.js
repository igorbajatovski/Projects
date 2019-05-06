// ###########################################################
function isLeftSideNumber(position, equation)
{
    let numbers = ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "."];
    let pos = position;
    while(numbers.includes(equation[pos]))
        pos -= 1;
    
    if( ["-", "+"].includes(equation[pos]))
    {
        if(pos > 0)
        {
            if( ["/", "*", "-", "+"].includes(equation[pos-1]))
                pos -= 1;
        }
        else
        {
            pos -= 1;
        }
    }
    
    if(pos === position)
        return -1;
    
    return pos+1;
}

function isRightSideNumber(position, equation)
{
    let numbers = ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "."];
    let operators = ["-", "+"];
    let pos = position;

    if(operators.includes(equation[pos]))
        pos += 1;

    while(numbers.includes(equation[pos]))
        pos += 1;
    
    if(pos === position)
        return -1;
    
    return pos;
}
// ##############################################################
// This function adds small brackets to the equation
function parseEquation(equation)
{
    let operators = ["/", "*", "-", "+"];
    equation = equation.replace(new RegExp(" ", "g"), "");
    let sbEquation = new StringBuffer(equation);

    for(let i = 0; i < 4; ++i)
    {
        let operator = operators[i];
        for(let j = 0; j < sbEquation.length(); ++j)
        {
            if( sbEquation.getItem(j) === operator && j > 0 && 
               ( !operators.includes(sbEquation.getItem(j-1)) && sbEquation.getItem(j-1) !== "(") )
            {
                
                let leftSideIndex = isLeftSideNumber(j-1, sbEquation.toString());
                let rightSideIndex = isRightSideNumber(j+1, sbEquation.toString());
                
                // If left side is number
                if(leftSideIndex > -1)
                {
                    sbEquation.insert(leftSideIndex, "(");
                    // if right side is not a number do not increment
                    if(rightSideIndex !== -1)
                        rightSideIndex += 1;
                }
                else // If left side is not number
                {
                    let k = j-1;
                    let endOfExpression = 0;

                    do{
                        if(sbEquation.getItem(k) === ")")
                            endOfExpression += 1;
                        else if(sbEquation.getItem(k) === "(")
                            endOfExpression -= 1;
                        k -= 1;
                    }while(endOfExpression !== 0)

                    sbEquation.insert(k+1, "(");

                    // if right side is not a number do not increment
                    if(rightSideIndex !== -1)
                        rightSideIndex += 1;
                }

                // If right side is number
                if(rightSideIndex > -1)
                {
                    sbEquation.insert(rightSideIndex, ")");
                }
                else // If right side is not number
                {
                    let k = rightSideIndex;

                    // if right side is not a number set k to j+2
                    if(rightSideIndex === -1)
                        k = j+2;

                    let endOfExpression = 0;

                    do{
                        if(sbEquation.getItem(k) === "(")
                            endOfExpression += 1;
                        else if(sbEquation.getItem(k) === ")")
                            endOfExpression -= 1;
                        k += 1;
                    }while(endOfExpression !== 0)

                    sbEquation.insert(k, ")");
                }

                j += 2;
            }// end of if
        }// end of for
    }// end of for

    let stringEquation = sbEquation.toString();
    if(stringEquation.includes("(") && stringEquation.includes(")"))
        return stringEquation;
    else
        return `(${stringEquation})`;
}
// ########################################################################