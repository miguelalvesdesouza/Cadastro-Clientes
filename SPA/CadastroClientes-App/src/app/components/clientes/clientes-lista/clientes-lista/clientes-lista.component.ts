import { HttpClient } from '@angular/common/http';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Cliente } from 'src/models/Cliente';
import { ClienteService } from 'src/services/cliente.service';

@Component({
  selector: 'app-clientes-lista',
  templateUrl: './clientes-lista.component.html',
  styleUrls: ['./clientes-lista.component.css']
})
export class ClientesListaComponent implements OnInit {
  modalRef?: BsModalRef;

  public clientId: number
  public clientes: Cliente[] = [];

  constructor(
    private clienteService: ClienteService,
    private modalService: BsModalService,
    private router: Router,
    private http: HttpClient
    ) { }

  ngOnInit(): void {
    this.carregarClientes();
  }

  public carregarClientes(): void{
    this.clienteService.getClientes().subscribe({
      next: (cliente: Cliente[]) => this.clientes = cliente,
      error: error => console.log(error)
    })
  }

  buscarCliente(id: number): void{
    this.router.navigate([`clientes/editar/${id}`])
  }

  openModal(client: any, template: TemplateRef<any>, clienteId: number): void{
    client.stopPropagation();
    this.clientId = clienteId;
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  decline(): void{
    this.modalRef?.hide()
  }

  confirm(): void{
    this.modalRef?.hide()
    this.clienteService.delete(this.clientId).subscribe(
      () => this.carregarClientes(),
      (error: any) => console.error(error)
    )
  }

}
