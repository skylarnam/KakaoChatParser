# KakaoChatParser

A KakaoTalk chat parser that generates a CSV output with the chat frequency broken down by participant.

## Input
Required
 - File path (`--filepath`): The input file path exported from KakaoTalk.
 - Output path (`--outputpath`): The output folder (e.g. `C:\Users\user\Downloads`) to create the output file.
 
Optional
 - Start date (`--startdate`): The start date (format: yyyyMMdd) to start parsing chats. _Inclusive_.
   - e.g. 20230325
 - End date (`--enddate`): The end date (format: yyyyMMdd) to stop parsing chats. _Exclusive_.

## Output
CSV file, in the format below:

|  Key  |  Value  |
| ----- |  ------ |
| Nickname A | 89 |
| Nickname B | 87 |
| Nickname C | 5  |
