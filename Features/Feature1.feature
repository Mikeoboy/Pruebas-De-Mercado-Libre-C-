Feature: MercadoLibreTests

Esta suite es para crear pruebas de mercado libre 

@Test1
Scenario: Buscar iPhone en mercado libre
	Given Navegar a Mecado Libre
	When Buscar Iphone
	Then Deberia aparecer una lista de iPhones

@Test2
Scenario: Añadir un articulo al carrito de compras 
	Given Navegar a Mecado Libre
	When Buscar Iphone
	Then Añadir articulo al carrito y verificar que este ahi
	
@Test3
Scenario: Comprobar los headers Menu Categories en mercado libre
	Given Navegar a Mecado Libre
	Then Verificar los headers Menu Categories
	| Lista de headers que debe tener  |
	| Categorías  |
	| Ofertas     |
	| Historial   |
	| Supermercado|
	| Moda        |
	| Vender      |
	| Ayuda		  |

@Test4
Scenario: verificar las opciones del DropDown Categoria
	Given Navegar a Mecado Libre
	When Click en categoria 
	Then Verificar valores del dropdown categories
	| Lista de opciones que debe tener el dropdown	|
	|Vehículos										|
	| Supermercado									|
	| Tecnología									|
	| Electrodomésticos								|
	| Hogar y Muebles								|
	| Moda											|
	| Deportes y Fitness							|
	| Herramientas									|
	| Deportes y Fitness							|
	| Construcción									|
	| Industrias y Oficinas							|
	| Accesorios para Vehículos						|
	| Juegos y Juguetes								|
	| Bebés											|
	| Salud y Equipamiento Médico					|
	| Belleza y Cuidado Personal					|
	| Inmuebles										|
	| Compra Internacional							|
	| Productos Sustentables						|
	| Más vendidos									|
	| Tiendas oficiales								|
	| Ver más categorías							|
	
