export class QuoteRequest {
  author: string;
  text: string;

  constructor(author: string, text: string) {
    this.author = author;
    this.text = text;
  }
}
