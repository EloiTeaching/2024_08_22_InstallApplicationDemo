-- Lua script demonstrating basic concepts

-- String operations
local str = "Hello, Lua!"
print("String: " .. str)
print("Length of the string: " .. #str)
print("Substring (1, 5): " .. string.sub(str, 1, 5))
print("Uppercase: " .. string.upper(str))

-- Tables as arrays
local array = {10, 20, 30, 40}
print("\nArray elements:")
for i, v in ipairs(array) do
    print("Index " .. i .. ": " .. v)
end

-- Tables as dictionaries
local dict = {name = "Lua", version = 5.4}
print("\nDictionary entries:")
for key, value in pairs(dict) do
    print(key .. ": " .. tostring(value))
end

-- Adding a method to a table (acting like a class)
local Person = {}
Person.__index = Person

-- Constructor
function Person.new(name, age)
    local self = setmetatable({}, Person)
    self.name = name
    self.age = age
    return self
end

-- Method
function Person:greet()
    return "Hello, my name is " .. self.name .. " and I am " .. self.age .. " years old."
end

-- Creating an instance and using the method
local person1 = Person.new("Alice", 30)
print("\nPerson greeting:")
print(person1:greet())

-- Updating a table with a new key-value pair
person1.occupation = "Engineer"
print("\nUpdated Person entries:")
for key, value in pairs(person1) do
    print(key .. ": " .. tostring(value))
end
