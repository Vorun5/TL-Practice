import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

class TodoItem {
  public id: number;
  public name: string;
  public done: boolean;

  constructor(name: string) {
    this.id = 0;
    this.name = name;
    this.done = false;
  }
}

@Component({
  selector: 'app-todo-list',
  templateUrl: './todo-list.component.html',
  styleUrls: ['./todo-list.component.css']
})
export class TodoListComponent implements OnInit {
  currentTodoItemName = '';
  todoItems: TodoItem[] = [];

  private _http: HttpClient;

  constructor(http: HttpClient) {
    this._http = http;
  }

  async ngOnInit(): Promise<void> {
    this.todoItems = await this._http.get<TodoItem[]>('/api/todo').toPromise();
  }

  async addTodoItem() {
    let newToDo: TodoItem = new TodoItem(this.currentTodoItemName);
    let newToDoId: number = await this._http.post<number>('/api/todo', newToDo).toPromise();
    newToDo.id = newToDoId;

    this.todoItems.push(newToDo);
    this.currentTodoItemName = '';
  }


  async updateTodoItem(todo: TodoItem) {
    await this._http.put('/api/todo/' + todo.id, todo).toPromise();
  }
}