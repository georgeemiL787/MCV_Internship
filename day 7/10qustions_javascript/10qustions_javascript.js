//1. swap 2 variables without using a third variable
let a = 5;
let b = 10;
console.log("a old value:", a);
console.log("b old value:", b);
[a, b] = [b, a];
console.log("a:", a); 
console.log("b:", b);
// another answer 
let x = 3;
let y = 7;
console.log("a old value:", a);
console.log("b old value:", b);
x = x + y; 
y = x - y; 
x = x - y; 
console.log("x:", x); 
console.log("y:", y); 

//2. Find the maximum number in an array.
let numbers = [3, 5, 7, 2, 8, 1];
let maxNumber = Math.max(...numbers);
console.log("Maximum number in the array:", maxNumber);
//another answer
let arr = [3, 5, 7, 2, 8, 1];
let max = arr[0];
for (let i = 1; i < arr.length; i++) {
    if (arr[i] > max) {
        max = arr[i];
    }
}
console.log("Maximum number in the array:", max);
//  3. Count vowels in a string.
let str ="hello world"
let count = 0
for (let i=0;i<str.length;i++){
    if (str[i]=="i"||str[i]=="a"||str[i]=="e"||str[i]=="o"||str[i]=="u"){
        count=count+1
    }
    
}
console.log("Number of vowels in the string:", count);
//4. Check if a number is prime.
let prime = 5
if (prime<=1){
console.log("false")
}
for(let i=2;i<prime;i++){
if(prime % i==0) {console.log("false")
}
else {
    console.log("True")

}

}
//5. Reverse a string
let sus="hello"
let rev=""
for (let i=sus.length-1;i>=0;i--){
rev=rev+sus[i]
}
console.log(rev)
//6. Sum only even numbers in an array.
let nums = [1, 2, 3, 4, 5, 6];
let sum=0
for (let i = 0; i < nums.length; i++){
    if (nums[i]%2==0){
        sum=sum+nums[i]

    }

}
console.log("the sum of even number",sum)
//7. Remove duplicates from an array.
let arr1 = [1, 2, 2, 3, 4, 4, 5];
let unique = [];

for (let i = 0; i < arr1.length; i++) {
    if (!unique.includes(arr1[i])) {
        unique.push(arr1[i]);
    }
}

console.log("Array without duplicates:", unique);

//8. FizzBuzz challenge
for(let i =1 ; i<=30;i++){
    if(i%3==0&&i%5==0){console.log("FizzBuzz")}
    else if(i%5==0){console.log("Buzz")}
    else if(i%3==0){console.log("Fizz")}
    else {console.log(i)}
}
//9. Factorial of a number using a function.
function factorial1( ab){
    let facto =1
    if (ab==0) {
        console.log(1)
        return;
    }
    else {
        for(let i=1;i<=ab;i++)
            facto=facto*i
        
    }
    console.log("Factorial = ",facto)
}
// another answer
function factorial2(n) {

if (n === 0 || n === 1) {
    return 1;
} 
else {
    return n * factorial2(n - 1);}
}

factorial1(5)
console.log("Factorial = ",factorial2(4))
//10. Create an object and loop over its properties.
let car = { brand: "Toyota", model: "Corolla", year: 2020, color: "blue" };
for (let key in car) {
    console.log(key + ": " + car[key]);
}
