// Check if expresion is number. If expression contians "(", ")", "+", "-", "*", "/"
// then the expression is not a number.
function isNumber(expression)
{   
    if(expression.indexOf("(") > -1 && expression.indexOf(")") > -1)
       return false;
    return true;
}

function getOperation(equation)
{
    // Remove the first and last bracket
    equation = equation.substring(1);
    equation = equation.substring(0, equation.length-1);
    
    // Get left hand operand
    let i = 0;
    if(equation.startsWith("("))
    {   
        let endOfExpression = 0;
        do{
            if(equation[i] === "(")
                endOfExpression += 1;
            else if(equation[i] === ")")
                endOfExpression -= 1;
            i += 1;
        }while(endOfExpression !== 0)
    }
    else
    {
        let operators = ["/", "*", "-", "+"];
        if(["+", "-"].includes(equation[i]))
            i += 1;
        while( !operators.includes(equation[i]) && i < equation.length )
            i += 1;
    }

    let leftHandSide = equation.substring(0, i);
    
    // Get operator
    let oper = equation.substring(i, i+1);

    // Get right hand operand
    let righHandSide = equation.substring(i+1, equation.length);

    // Check if left side is number
    let isLeftHandANumber = false;
    if(isNumber(leftHandSide))
        isLeftHandANumber = true;

    // Check if right side is number
    let isRightHandANumber = false;
    if(isNumber(righHandSide))
        isRightHandANumber = true;

    return {leftSide: leftHandSide, isLeftSideANumber: isLeftHandANumber, 
            rightSide: righHandSide, isRightSideANumber: isRightHandANumber, 
            operator: oper};
}


function calculate(equation)
{
    let operation = getOperation(equation);
    let result = 0;
    if(operation.operator === "+")
    {
        if(!operation.isLeftSideANumber && !operation.isRightSideANumber)
            result = calculate(operation.leftSide) + calculate(operation.rightSide);
        if(operation.isLeftSideANumber && !operation.isRightSideANumber)
            result = Number(operation.leftSide) + calculate(operation.rightSide);
        if(!operation.isLeftSideANumber && operation.isRightSideANumber)
            result = calculate(operation.leftSide) + Number(operation.rightSide);
        if(operation.isLeftSideANumber && operation.isRightSideANumber)
            result = Number(operation.leftSide) + Number(operation.rightSide);
        
        // console.log(`${operation.leftSide} ${operation.operator} ${operation.rightSide} = ${result}`);
    }

    if(operation.operator === "-")
    {
        if(!operation.isLeftSideANumber && !operation.isRightSideANumber)
            result = calculate(operation.leftSide) - calculate(operation.rightSide);
        if(operation.isLeftSideANumber && !operation.isRightSideANumber)
            result = Number(operation.leftSide) - calculate(operation.rightSide);
        if(!operation.isLeftSideANumber && operation.isRightSideANumber)
            result = calculate(operation.leftSide) - Number(operation.rightSide);
        if(operation.isLeftSideANumber && operation.isRightSideANumber)
            result = Number(operation.leftSide) - Number(operation.rightSide);

        // console.log(`${operation.leftSide} ${operation.operator} ${operation.rightSide} = ${result}`);
    }

    if(operation.operator === "*")
    {
        if(!operation.isLeftSideANumber && !operation.isRightSideANumber)
            result = calculate(operation.leftSide) * calculate(operation.rightSide);
        if(operation.isLeftSideANumber && !operation.isRightSideANumber)
            result = Number(operation.leftSide) * calculate(operation.rightSide);
        if(!operation.isLeftSideANumber && operation.isRightSideANumber)
            result = calculate(operation.leftSide) * Number(operation.rightSide);
        if(operation.isLeftSideANumber && operation.isRightSideANumber)
            result = Number(operation.leftSide) * Number(operation.rightSide);

        // console.log(`${operation.leftSide} ${operation.operator} ${operation.rightSide} = ${result}`);
    }

    if(operation.operator === "/")
    {
        if(!operation.isLeftSideANumber && !operation.isRightSideANumber)
            result = calculate(operation.leftSide) / calculate(operation.rightSide);
        if(operation.isLeftSideANumber && !operation.isRightSideANumber)
            result = Number(operation.leftSide) / calculate(operation.rightSide);
        if(!operation.isLeftSideANumber && operation.isRightSideANumber)
            result = calculate(operation.leftSide) / Number(operation.rightSide);
        if(operation.isLeftSideANumber && operation.isRightSideANumber)
            result = Number(operation.leftSide) / Number(operation.rightSide);

        // console.log(`${operation.leftSide} ${operation.operator} ${operation.rightSide} = ${result}`);
    }

    if(operation.operator === "")
    {
        result = Number(operation.leftSide);
    }

    return result;
}