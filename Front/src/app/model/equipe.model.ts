import { DomainBase } from "../domain/base/base.domain";

export class EquipeModel extends DomainBase {
  
  public Nome: string;
  public Sigla: string;
  public Gols: number;

  constructor(data: any = {}) {
    super();

    if (data == null) {
      data = {};
    }

    this.Id = data.id || null;
    this.Nome = data.nome || null;
    this.Sigla = data.sigla || null;
    this.Gols = data.gols || 0;
  }
}
