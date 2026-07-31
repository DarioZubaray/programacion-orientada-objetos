# Definiciones y Restricciones

## Institutos

### Alta nuevo Instituto
- El codigo de id ingresado debe ser unico
- Ningun campo puede estar vacio (Codigo, Nombre, Telefono, Direccion)

### Modificacion instituto seleccionado
- NO permito modificar el Codigo que se ingreso

### Borrar instituto seleccionado
- No permitir bajas con pagos pendientes a proveedores

## Proveedores

### Alta nuevo Proveedor
- El codigo de id ingresado debe ser unico
- Ningun campo puede estar vacio (Codigo, Nombre o razonSocial, Telefono)
 
### Modificacion proveedor seleccionado
- NO permito modificar el id que se ingreso

### Borrar proveedor seleccionado
- No permitir bajas con relaciones activas (institutos asignados o pagos por cobrar).

## Asignaciones

### Asignar Prestador
- Se podra asignar el proveedor seleccionado al instituto seleccionado si no asigno previamente

### Generar Pagos
- Ningun campo puede estar vacio (Importe, FechaVencimiento, TipoPago = 'Transaccion')
- Se permite generar multiples pagos hacia proveedores asignados

### Pagar
- grilla5 ordenados por fecha ascendente.
- Se podra pagar si existe pago seleccionado(grilla5) y se encuentre en estado NO_CANCELADO
- Si el pago se efectua despues de la fecha de vencimiento se aplica recargo segun tipo
- Si el total abonado supera los 15.000 se muestra un mensaje en pantalla