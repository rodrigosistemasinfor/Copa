import { JsonProperty, ObjectMapper } from "json-object-mapper";

export abstract class DomainBase {
  @JsonProperty({ name: "id" })
  public Id: string;

  public toJSON(): string | any {
    return <string>ObjectMapper.serialize(this);
  }
}
