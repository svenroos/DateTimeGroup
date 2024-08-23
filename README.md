# DateTimeGroup / DTG
DateTimeGroup extension for DateTime

This adds an extension to DateTime struct to be able to handle DateTimeGroup formats.
For detailed information on dateTimeGroup please refer to e.g. https://en.wikipedia.org/wiki/Date-time_group

A date and time is given by e.g.
230753ZAUG24, representing 07:53h on 23rd Aug 2024 at UTC+0.

The extension adds the folloiwng feaures:
- print any DateTime in DTG format for a desired timezone
- convert any string in DTG format to a DateTime

