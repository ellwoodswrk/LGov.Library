# Local Gov Code Library

Library of extensions and models for netstandard 2.0 and .NET 8
This is the latest c# incarnation of this library. Some of the functionality is now available in standard libraries and can be ignored, it has been left in for legacy reasons in particular where there are slight differences in functionality. The library provides various generic functions e.g. string and DateTime and also provides functions and models based on local government in the UK, e.g. UPRN, USRN.

## Extensions

### DateTime

This includes date calculations and checks. Unless otherwise specified these are based on UK format dates

- Easter date
- First Monday of month date
- ISO Week
- Last day of month
- Last Monday of month date
- Next Monday date
- RSSFormat - Format date as RSS style DateTime
- Between - Determines if a date is between two others
- Previous 1st April date
- Is UK English bank holiday
- Is English bank holiday week - is there an english/welsh bank holiday in this week (starting on the Monday)
- Is UK English working day - this checks if the day is a weekend or an english/welsh bank holiday
- Daylight Savings Time UK end - Date that DST ends in the UK
- Daylight Savings Time UK start - Start of DST in the UK
- Is in daylight savings time UK
- Is Date
- Is Any Date - checks if date, including Unix style dates

## Dependencies

None

© SE 2024
