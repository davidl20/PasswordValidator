# PasswordValidator
**PasswordValidator** es una aplicación de escritorio desarrollada con **C#, .NET 9 y Windows Forms** que permite generar contraseñas aleatorias mediante conjuntos de caracteres y restricciones configurables, así como calcular el número total de combinaciones posibles según la configuración seleccionada.

La aplicación utiliza un generador de números aleatorios criptográficamente seguro para generar contraseñas y `BigInteger` para realizar cálculos combinatorios sin desbordamientos numéricos.

## Capturas de pantalla

En esta sección se muestran las principales funcionalidades de la aplicación.

### Interfaz principal

<img width="694" height="317" alt="image" src="https://github.com/user-attachments/assets/4ac8c0f5-a446-424b-b6fc-c4e5cbda6f18" />

### Generación de contraseñas

<img width="692" height="313" alt="image" src="https://github.com/user-attachments/assets/689e68aa-d9ee-46bc-b06e-967439b96398" />

### Cálculo de combinaciones

<img width="691" height="314" alt="image" src="https://github.com/user-attachments/assets/47915622-92e5-4c12-af2e-3157b5ca7704" />

## Características

- **Longitud configurable:** permite seleccionar longitudes de entre 1 y 64 caracteres mediante un control deslizante (`TrackBar`).
- **Selección de caracteres:** permite habilitar o deshabilitar los siguientes conjuntos:
  - Minúsculas (`a-z`): 26 caracteres.
  - Mayúsculas (`A-Z`): 26 caracteres.
  - Dígitos (`0-9`): 10 caracteres.
  - Símbolos: 32 caracteres.
- **Restricciones de generación:**
  - `Start With Letter`: la contraseña debe comenzar con una letra.
  - `Start With Upper`: la contraseña debe comenzar con una letra mayúscula.
  - `Must Contain Digit`: la contraseña debe contener al menos un dígito cuando esta restricción sea aplicable.
- **Generación segura:** utiliza un generador criptográfico de números aleatorios del sistema.
- **Copiado al portapapeles:** permite copiar la contraseña generada con un solo clic.
- **Cálculo combinatorio:** calcula el número de contraseñas posibles según la longitud, los caracteres habilitados y las restricciones seleccionadas.
- **Números de gran tamaño:** utiliza `BigInteger` para representar cantidades que exceden la capacidad de los tipos numéricos convencionales.
- **Validación de configuración:** contempla configuraciones incompatibles para evitar generar contraseñas que no cumplan las restricciones solicitadas.

## Tecnologías utilizadas

| Tecnología | Uso |
|---|---|
| C# | Lenguaje de programación. |
| .NET 9 | Plataforma de desarrollo. |
| Windows Forms | Construcción de la interfaz gráfica. |
| `System.Security.Cryptography` | Generación de números aleatorios criptográficamente seguros. |
| `System.Numerics.BigInteger` | Cálculos combinatorios de gran magnitud. |
| Git | Control de versiones. |

## Estructura del repositorio

```text
PasswordValidator/
├── PasswordValidator.slnx
├── README.md
├── docs/
│   └── images/
│       ├── main-window.png
│       ├── password-generation.png
│       └── combinations-calculation.png
└── PasswordValidator/
    ├── PasswordValidator.csproj
    ├── Program.cs
    ├── MainForm.cs
    ├── MainForm.Designer.cs
    ├── MainForm.resx
    ├── GenerateConfig.cs
    ├── PasswordGenHelper.cs
    └── SecureRandom.cs
```

### Descripción de archivos

| Archivo | Responsabilidad |
|---|---|
| `Program.cs` | Punto de entrada de la aplicación. Inicializa la configuración de Windows Forms y ejecuta `MainForm`. |
| `MainForm.cs` | Gestiona los eventos de la interfaz, construye la configuración y delega la generación y el cálculo. |
| `MainForm.Designer.cs` | Contiene la definición de los controles de la interfaz generados por el diseñador. |
| `MainForm.resx` | Almacena los recursos asociados al formulario. |
| `GenerateConfig.cs` | Representa la configuración de generación, incluyendo longitud, conjuntos de caracteres y restricciones. |
| `PasswordGenHelper.cs` | Centraliza la lógica de generación de contraseñas y cálculo combinatorio mediante `BigInteger`. |
| `SecureRandom.cs` | Encapsula las operaciones de generación aleatoria segura basadas en `RandomNumberGenerator.GetInt32`. |
| `PasswordValidator.csproj` | Define la configuración y las dependencias del proyecto. |
| `PasswordValidator.slnx` | Contiene la solución de Visual Studio. |

## Arquitectura y flujo de funcionamiento

La aplicación separa la interfaz gráfica de la lógica de generación y cálculo.

```text
                  MainForm (UI)
                       |
                       | Lee las opciones seleccionadas
                       | y construye GenerateConfig
                       v
                 GenerateConfig
                       |
                       v
                PasswordGenHelper
                  /            \
                 /              \
                v                v
      GeneratePassword()   CalculateTotalCombinations()
                |                |
                v                v
           SecureRandom       BigInteger
                |
                v
      Generador criptográfico
           del sistema
```

### Responsabilidades

- **MainForm:** recopila las opciones del usuario, valida la configuración y muestra los resultados.
- **GenerateConfig:** representa los parámetros utilizados por los procesos de generación y cálculo.
- **PasswordGenHelper:** centraliza las reglas de generación y las fórmulas combinatorias para mantener la coherencia entre ambos procesos.
- **SecureRandom:** proporciona acceso a la generación aleatoria criptográficamente segura.

## Requisitos

Para compilar y ejecutar la aplicación necesitas:

- Windows compatible con Windows Forms.
- .NET 9 SDK.
- Visual Studio 2022 o una versión compatible, de forma opcional.

La aplicación utiliza el framework `net9.0-windows`, por lo que su ejecución requiere Windows.

## Compilación y ejecución

### 1. Clonar el repositorio

```bash
git clone <URL_DEL_REPOSITORIO>
cd PasswordValidator
```

Reemplaza `<URL_DEL_REPOSITORIO>` por la URL real del repositorio.

### 2. Compilar la solución

Desde la raíz del repositorio, ejecuta:

```bash
dotnet build PasswordValidator.slnx
```
### 3. Ejecutar la aplicación

En Windows, ejecuta:

```bash
dotnet run --project PasswordValidator/PasswordValidator.csproj
```

También puedes abrir `PasswordValidator.slnx` en Visual Studio y ejecutar el proyecto mediante `F5`.

## Uso de la aplicación

1. **Configurar la longitud:** ajusta el control deslizante para seleccionar la cantidad de caracteres deseada.
2. **Seleccionar los caracteres:** habilita los conjuntos de minúsculas, mayúsculas, dígitos y símbolos que quieras utilizar.
3. **Configurar las restricciones:** selecciona si la contraseña debe comenzar con una letra, comenzar con una mayúscula o contener al menos un dígito.
4. **Generar la contraseña:** pulsa `Generate` para crear una contraseña que cumpla las restricciones aplicables.
5. **Copiar la contraseña:** pulsa `Copy` para copiar el resultado al portapapeles.
6. **Calcular las combinaciones:** pulsa `Calcular` para obtener el número de contraseñas posibles con la configuración actual.

### Configuraciones inválidas

La aplicación contempla situaciones en las que no es posible satisfacer las restricciones seleccionadas.

Por ejemplo:

- No se ha seleccionado ningún conjunto de caracteres.
- Se exige una mayúscula inicial, pero las mayúsculas están deshabilitadas.
- La longitud y las restricciones seleccionadas no permiten formar una contraseña válida.

En estos casos, la aplicación debe informar al usuario o devolver cero combinaciones, según el flujo implementado.

## Fundamentos matemáticos

El número de contraseñas posibles depende del tamaño del alfabeto disponible, la longitud de la contraseña y las restricciones aplicadas.

Se utilizan las siguientes variables:

- \(T\): cantidad total de caracteres habilitados.
- \(L\): longitud de la contraseña.
- \(F\): cantidad de caracteres permitidos en la primera posición.
- \(F'\): cantidad de caracteres permitidos en la primera posición que no son dígitos.
- \(D\): cantidad de dígitos disponibles, normalmente 10 si están habilitados y 0 en caso contrario.

### Sin requisito de dígito

Cuando la primera posición puede contener cualquiera de los \(F\) caracteres permitidos y las posiciones restantes pueden utilizar cualquier carácter del alfabeto:

\[
N=F \times T^{L-1}
\]

Si no existen restricciones para la primera posición, entonces \(F=T\), por lo que:

\[
N=T^L
\]

### Con requisito de al menos un dígito

Para calcular las combinaciones que contienen al menos un dígito se utiliza el principio de complemento.

Se resta del total de combinaciones el número de contraseñas que no contienen ningún dígito:

\[
N=F \times T^{L-1}
-F' \times (T-D)^{L-1}
\]

En esta expresión, \(F'\) representa los caracteres válidos para la primera posición que no son dígitos.

La fórmula contempla tanto las restricciones de inicio como la obligación de incluir al menos un dígito, siempre que los valores de \(F\), \(F'\), \(T\) y \(D\) se calculen de acuerdo con los caracteres realmente habilitados.

### Ejemplo

Supongamos una contraseña con las siguientes características:

- Longitud: 8 caracteres.
- Minúsculas, mayúsculas, dígitos y símbolos habilitados.
- Sin restricciones de inicio.
- Al menos un dígito obligatorio.

El alfabeto contiene:

\[
T=26+26+10+32=94
\]

Como existen 10 dígitos, el número de caracteres no numéricos es:

\[
T-D=94-10=84
\]

Por el principio de complemento, el número de contraseñas válidas es:

\[
N=94^8-84^8
\]

El resultado se presenta en la aplicación con separadores de miles para facilitar su lectura.

### Precisión de los cálculos

La implementación utiliza `BigInteger`, lo que permite representar los resultados sin el desbordamiento habitual de los tipos numéricos enteros de tamaño fijo.

El cálculo representa el espacio de búsqueda teórico para la configuración seleccionada. No equivale directamente al tiempo necesario para descubrir una contraseña, ya que este depende de otros factores, como el mecanismo de autenticación y la capacidad de procesamiento del atacante.

## Seguridad

La aplicación utiliza `RandomNumberGenerator.GetInt32` como fuente de aleatoriedad criptográficamente segura.

Esta elección evita depender de `System.Random`, que no está diseñado para generar secretos criptográficos.

No obstante, la seguridad del resultado también depende de la implementación del algoritmo de selección de caracteres y de que se respeten las restricciones configuradas.

Se recomienda:

- Utilizar contraseñas únicas para cada servicio.
- Evitar compartir las contraseñas generadas.
- Almacenarlas en un gestor de contraseñas confiable.
- Verificar que la selección de caracteres no introduzca sesgos en la distribución.

## Notas de implementación

- **Lógica centralizada:** la interfaz delega la generación y el cálculo en `PasswordGenHelper`, evitando duplicar las reglas de negocio.
- **Aleatoriedad criptográfica:** `SecureRandom` utiliza `RandomNumberGenerator.GetInt32` como fuente de números aleatorios.
- **Precisión numérica:** `BigInteger` permite manejar cantidades muy grandes de combinaciones.
- **Coherencia del alfabeto:** la generación y el cálculo deben utilizar los mismos conjuntos de caracteres: 26 minúsculas, 26 mayúsculas, 10 dígitos y 32 símbolos.
- **Restricción de dígitos:** cuando los dígitos están deshabilitados, la obligación de incluir uno no puede satisfacerse. El comportamiento debe gestionarse explícitamente para evitar resultados inválidos o ciclos de generación indefinidos.
- **Restricciones de inicio:** si se exige una mayúscula inicial, la configuración debe permitir mayúsculas. Cuando se combinan las restricciones de inicio, la generación y el cálculo deben aplicar las mismas reglas.
