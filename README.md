# Proyecto de Extracción de rasgos faciales en Frames de Video con OpenCV y Emgu.CV en .NET

## Librerías Utilizadas:
- **Emgu.CV:** Biblioteca de visión por computadora basada en OpenCV para .NET.

## Paquetes Nuget instalados:
- **Emgu.CV** versión 4.8.1.5350
- **Emgu.CV.runtime.windows** versión 4.8.1.5350

## Segunda parte de la prueba:

En primer lugar, es necesario que crees un programa en .NET, con C# de consola para leer con OpenCV un video de 10 segundos y transformar ese video en imágenes (Frames) y que se guarde en una carpeta a parte.

## Funcionamiento de la solución

Para esto, utilicé el mismo código del paso anterior, pero, lo separé para comenzar a escalarlo en base a las necesidades de la prueba.

En base a esto, creé el método “AnalizarCarasEnTiempoReal”. Este método realiza el análisis utilizando la biblioteca OpenCV a través de Emgu.CV. Se cargan los archivos XML que contienen los clasificadores previamente entrenados para caras, ojos y nariz. Se crean instancias de CascadeClassifier para cada clasificador utilizando los archivos XML cargados.
Utilizamos la misma función del primer código, “VideoCapture” para abrir el video específico y obtener la tasa de frames por segundo.
Se inicia un bucle con la condición de seguir ejecutandose mientras hay frames en el video. Dentro del bucle se realiza esto:

Se convierte cada frame a escala de grises para facilitar el procesamiento.
Se detectan las caras en el frame utilizando el clasificador de caras.
Por cada cara detectada, se extrae la región de la cara, se guarda como imagen y se dibuja un rectángulo alrededor de la cara en el frame original
Se realiza un proceso similar para la detección de ojos y narices dentro de la región de la cara.
Se muestra el frame resultante en tiempo real.
El bucle se repite hasta que se procesan todos los frames del video.

## Imágenes de la solución

![image](https://github.com/KevinJose37/DeteccionCaras/assets/108701677/7b3178e7-86f7-4426-8312-c576195b3a54)

![image](https://github.com/KevinJose37/DeteccionCaras/assets/108701677/8d237f41-6827-4f8e-b72c-1978cf08f981)

![image](https://github.com/KevinJose37/DeteccionCaras/assets/108701677/336a70d6-35d3-4c88-8742-8f36bd51aea4)

## Video de la solución
https://github.com/KevinJose37/DeteccionCaras/assets/108701677/004d80a1-8638-4564-a055-e02b2f4e6a61

https://github.com/KevinJose37/DeteccionCaras/assets/108701677/a3fd08c5-2522-4c40-a7e4-e2f19c02ed3a



**Enlace de descarga del video https://we.tl/t-1Qjq4sF6Tc**
**Se recomienda un video de 1080 x 1920**

## Directorio de imágenes del dataset creado

![image](https://github.com/KevinJose37/DeteccionCaras/assets/108701677/4e8ef644-98f9-493d-b5ee-fc2cfa71cf47)

## Frame 204_nariz 
![204_nariz](https://github.com/KevinJose37/DeteccionCaras/assets/108701677/945bd567-8994-4e56-b2cb-68401707f0df)

## Frame 204_ojos

![204_ojo](https://github.com/KevinJose37/DeteccionCaras/assets/108701677/1b65bf85-f6fd-46eb-a151-7afd005d8a08)

## Frame 204_rostro

![204_cara](https://github.com/KevinJose37/DeteccionCaras/assets/108701677/7c4a9a27-7c86-4b2c-a662-0bb6e56e4162)






