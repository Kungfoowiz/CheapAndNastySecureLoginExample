# CheapAndNastySecureLoginExample
<h4>Cheap and nasty (quick) secure login using SHA1</h4>

To configure users, add them to <em>Web.config</em>. <br/>
Browse to <b>/Account/Generate/?input=PASSWORD</b> to generate SHA1 hashes. 

Add <em><b>[XAuthorize]</b></em> to any controller or action to enforce the security. <br/>
It is a filter attribute inherited from <em>AuthorizeAttribute</em> class. 

