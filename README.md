<!--
  Title: Random Extensions
  Description: A collection of C# extension methods for System.Random class that helps to get random long integers, random dates, random list/array items, and to make random decisions when generating test data.
  Author: igor-krein
  -->
# RandomExtensions
## What is it
This is just a collection of C# extension methods for System.Random class. With their help you easily can:
- get random long integer value
- get random DateTime/Date value
- choose random item from the list
- throw virtual dice and/or darts

## What are they for
These methods are useful for generating data tasks. If you are starting a new project that should work with a lot of data which doesn't exist yet, the easiest way is to generate some virtual data for testing purposes. That's when RandomExtensions collection comes in handy.

**Note:** if you need some *secure* randomizer, look up elsewhere: these methods are based on standard unsecure methods of System.Random class.

## How to use them
In the src/RandomExtensionsExample folder, there is a working example with comments provided.

Here are some [edited] code snippets:

### Date generating
    Random _random = new Random();
    // Date of birth is a date between 1/1/1800 and a day that was 25 years ago
    DateTime birthFrom = new DateTime(1800, 1, 1);
    DateTime birthTo = DateTime.Now.AddYears(-25);
    DateTime birthDate = _random.NextDate(birthFrom, birthTo);

### Choosing random item from an array
    Random _random = new Random();
    string[] _lastNames = { "Johnson", "King", "Verne", "Hawk", "Sterling", "Stout", "Webster", "Knight", "Aston", "Anderson" };
    string lastName = _random.NextItem(_lastNames);

### Throwing dice and darts
    Random _random = new Random();
    string[] _firstNames = { "John", "Rex", "Andrew", "Jonathan", "Stephen", "Frederick", "Louis", "Matthew" };
    string middleName = null;

    // 1/3 persons to have a middle name
    if (_random.HitBullsEye(3))
    {
        // in 3 of 10 cases middle name is just a letter (like Jerome K. Jerome)
        middleName = _random.IsTrueWithProbability(0.3)
            ? $"{(char)('A' + _random.Next(0, 26))}."
            : _random.NextItem(_firstNames);
    }

## What if some very useful method is missing
Simply tell me of you idea or try to write it by yourself.
