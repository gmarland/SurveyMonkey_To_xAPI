# SurveyMonkey To xAPI
<p>This is a library that will convert a SurveyMonkey xurvey to xAPI statements. Obviously, the data is formatted to the schema present in the library (I might make this dynamic if people find it useful).</p>


###Verbs
<p>The verbs for each of the question types can be found in the modules /SurveyMonkeyToxAPI/Models/QuestionTypes/. These can be changed as required.</p>


###Email Address
<p>The users email address will be pulled from the metadata if the survey was distributed by email. If not, the first response containing an email address will be considered to be the users. This will then pull that question from the survey and use it to identify the responses. This should be bared in mind when using with a survey.</p>


##xAPI
<p>The main xAPI is generated in the following places and therefore can be modified if required:</p>
<p>
Question - /SurveyMonkeyToxAPI/Models/Question.cs - GetxAPIStatement
<br/>
Survey - /SurveyMonkeyToxAPI/Models/Survey.cs - GetxAPIStatement
</p>
<p>If you have any questions, please feel free to reach out.</p>
