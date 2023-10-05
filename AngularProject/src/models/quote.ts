export class Quote {
  id: number;
  author: string;
  text: string;

  constructor(id: number, author: string, text: string) {
    this.id = id;
    this.author = author;
    this.text = text;
  }
}
