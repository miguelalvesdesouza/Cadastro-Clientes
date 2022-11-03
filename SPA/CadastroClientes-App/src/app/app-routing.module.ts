import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClientesListaComponent } from './components/clientes/clientes-lista/clientes-lista/clientes-lista.component';
import { ClientesNovoComponent } from './components/clientes/clientes-novo/clientes-novo/clientes-novo.component';
import { ClientesComponent } from './components/clientes/clientes.component';

const routes: Routes = [
  {
    path: 'clientes', component: ClientesComponent,
    children: [
      {path: 'lista', component: ClientesListaComponent},
      {path: 'novo', component: ClientesNovoComponent},
      {path: 'editar/:id', component: ClientesNovoComponent}
    ]
  },
  {path: '', redirectTo: 'clientes', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
