import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Cliente } from 'src/models/Cliente';
import { ClienteService } from 'src/services/cliente.service';

@Component({
  selector: 'app-clientes-novo',
  templateUrl: './clientes-novo.component.html',
  styleUrls: ['./clientes-novo.component.css']
})
export class ClientesNovoComponent implements OnInit {
  idCliente = this.router.snapshot.paramMap.get('id');

  form: FormGroup;
  cliente: Cliente

  get f(): any {
    return this.form.controls;
  }

  constructor(
    private fb: FormBuilder,
    private clienteService: ClienteService,
    private router: ActivatedRoute

  ) { }

  ngOnInit() {
    this.validation();
    this.carregarCliente()
  }

  public validation(): void{
    this.form = new FormGroup({
      nome: new FormControl,
      telefone: new FormControl,
      endereco: new FormControl,
      data: new FormControl,
    })
  }

  public carregarCliente(): void{

    if(this.idCliente !== null)
    {
      this.clienteService.getClienteById(+this.idCliente).subscribe(
        (cliente: Cliente) => {
          this.cliente = {...cliente};
          this.form.patchValue(this.cliente)
        },
        (error: any) => console.error(error)
      )
    }
  }

  public salvar(): void{
    if(this.idCliente === null)
    {
      this.cliente = {...this.form.value}
      this.clienteService.post(this.cliente).subscribe({
        next: () => console.log("Salvo com sucesso"),
        error: error => console.error(error)
      })
    }
    else
    {
      this.cliente = {idCliente: this.cliente.idCliente,  ...this.form.value}
      this.clienteService.put(this.cliente).subscribe({
        next: () => console.log("Atualizado com sucesso"),
        error: error => console.error(error)
      })
    }
  }


}
