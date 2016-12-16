# SurveyMonkey To xAPI
This is a library that will convert a SurveyMonkey xurvey to xAPI statements. Obviously, the data is formatted to the schema present in the library (I might make this dynamic if people find it useful).


###Verbs
The verbs for each of the question types can be found in the modules /SurveyMonkeyToxAPI/Models/QuestionTypes/. These can be changed as required.


##xAPI
The main xAPI is generated in the following places and therefore can be modified if required:

Question - /SurveyMonkeyToxAPI/Models/Question.cs - GetxAPIStatement
Survey - /SurveyMonkeyToxAPI/Models/Survey.cs - GetxAPIStatement


If you have any questions, please feel free to reach out.
