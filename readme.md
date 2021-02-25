
##2. Describir si ha tenido problemas al integrar plugins de terceros para Android

Los problemas mas comunes fueron typos en los nombres de los métodos a la hora de invocarlos (nativos) y Constraints no definidos a la hora de integrar el plugin.

##3. Describir los pasos para crear un build y subirlo a TestFlight para iOS
Primero hay que buildear el proyecto de Xcode, despues archivas el proyecto, subirlo al iTunes Connect y rezar. (todo esto es automatizable con un buen Fastlane

Entre estos pasos pueden pasar mil cosas, que si están automatizadas te salvas bocha de dolores de cabeza entre estos:

- subir el bundle version/ build number
- setup de provisioning profiles
- setup de certificados ( development y produccion ) 
- AppID

Despues si mal no recuerdo, tenias que configurar en tesflight quienes tienen acceso a la build o que devices pueden bajar la app.