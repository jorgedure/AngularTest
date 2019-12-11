import { Component, OnInit } from '@angular/core';
import { trigger, transition, style, animate} from '@angular/animations';
import { TodoService } from '../../services/todo.service';
import { Todo } from '../../interfaces/todo';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';

@Component({
  selector: 'todo-list',
  templateUrl: './todo-list.component.html',
  styleUrls: ['./todo-list.component.scss'],
  providers:[TodoService],
  animations: [
    trigger('fade', [

      transition(':enter', [
        style({ opacity: 0, transform: 'translateY(30px)' }),
        animate(200, style({ opacity: 1, transform: 'translateY(0px)'}))
      ]),

      transition(':leave', [
        animate(200, style({ opacity: 0, transform: 'translateY(30px)' }))
      ]),

    ])
  ]
})

export class TodoListComponent implements OnInit {
  todoTitle: string;
  todos: Todo[] = [];

  constructor(private todoService: TodoService) {

   }

  ngOnInit() {
    this.getTodos();
    this.todoTitle = '';

  }
  addTodo(){
    if (this.todoTitle.trim().length === 0) {
      return;
    }
    this.todoService.addTodo(this.todoTitle).subscribe(result=>{
      this.getTodos()
    });

    this.todoTitle='';
  }

  getTodos() {
    this.todoService.getTodos().subscribe(x =>{
      this.todos = x;
    })
  }
  deleteTodo(id:number) {
      this.todoService.deleteTodo(id).subscribe(result => {
          this.getTodos()
      });
  }
  doneEdit(todo) {
      this.todoService.doneEdit(todo).subscribe(result => {
          this.getTodos()
      });
  }
  //checkAll() {
  //    this.todoService.checkAll().subscribe(result => {
  //        this.getTodos()
  //    })
  //}
}

