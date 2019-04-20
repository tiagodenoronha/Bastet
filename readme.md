# Bastet

[![Build Status](https://tiagodenoronha.visualstudio.com/Bastet/_apis/build/status/CI%20-%20Text%20Analyzer?branchName=master)](https://tiagodenoronha.visualstudio.com/Bastet/_build/latest?definitionId=6&branchName=master)
[![CodeFactor](https://www.codefactor.io/repository/github/tiagodenoronha/bastet/badge)](https://www.codefactor.io/repository/github/tiagodenoronha/bastet)
[![Bugs](https://img.shields.io/github/issues/tiagodenoronha/Bastet.svg)](https://github.com/tiagodenoronha/Bastet/issues?utf8=✓&q=is%3Aissue+is%3Aopen+label%3Abug)

This is a POC for an email classifier built using Azure components and Dynamics 365.

Whenever an email is received, a shared mailbox within the Dynamics 365 instance receives that email, and sends a message to an Azure Service Bus Queue with the body of that email. An Azure Function then procedes to handle the message, and, depending on the output, sends the result back to CRM.

The Azure Function first sanitizes the email body to remove the HTML tags, then sends it off to LUIS. Depending on the output from LUIS, it can call QnAMaker or Text Analysis to perform further analysis.

Afterwards, we apply an ML<span></span>.NET algorithm to predict which category the email belongs, sending a final message to another Queue for another Azure Function which has the purpose to insert the data into Dynamics 365.

In order to simplify the project, the Dynamics 365 solution will not be present in the repository. We will assume the queue receives messages from Dynamics 365.


## Contributing

First of all, thank you to everyone who contributes!

[![](https://sourcerer.io/fame/tiagodenoronha/tiagodenoronha/Bastet/images/0)](https://sourcerer.io/fame/tiagodenoronha/tiagodenoronha/Bastet/links/0)[![](https://sourcerer.io/fame/tiagodenoronha/tiagodenoronha/Bastet/images/1)](https://sourcerer.io/fame/tiagodenoronha/tiagodenoronha/Bastet/links/1)[![](https://sourcerer.io/fame/tiagodenoronha/tiagodenoronha/Bastet/images/2)](https://sourcerer.io/fame/tiagodenoronha/tiagodenoronha/Bastet/links/2)[![](https://sourcerer.io/fame/tiagodenoronha/tiagodenoronha/Bastet/images/3)](https://sourcerer.io/fame/tiagodenoronha/tiagodenoronha/Bastet/links/3)[![](https://sourcerer.io/fame/tiagodenoronha/tiagodenoronha/Bastet/images/4)](https://sourcerer.io/fame/tiagodenoronha/tiagodenoronha/Bastet/links/4)[![](https://sourcerer.io/fame/tiagodenoronha/tiagodenoronha/Bastet/images/5)](https://sourcerer.io/fame/tiagodenoronha/tiagodenoronha/Bastet/links/5)[![](https://sourcerer.io/fame/tiagodenoronha/tiagodenoronha/Bastet/images/6)](https://sourcerer.io/fame/tiagodenoronha/tiagodenoronha/Bastet/links/6)[![](https://sourcerer.io/fame/tiagodenoronha/tiagodenoronha/Bastet/images/7)](https://sourcerer.io/fame/tiagodenoronha/tiagodenoronha/Bastet/links/7)

If you are interested in fixing issues and contributing directly to the code base, be my guest! Just fork the repo and do your magic! :)
See the list of [contributors](https://github.com/tiagodenoronha/Bastet/contributors) who participated in this project.

Please see also the [Code of Conduct](CODE_OF_CONDUCT.md).


## License

Copyright (c) Tiago Noronha. All rights reserved.

Licensed under the [MIT](LICENSE) License.
