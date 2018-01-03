import React, { Component } from 'react';
import axios from "axios";
import BotaoContador from "./BotaoContador";
import logo from './logo.svg';
import './App.css';

class App extends Component {
    state = {
        retorno: "",
    };
    listar = () => {
        axios.get("api/Teste/ListarTodos").then((response) => this.setState({ retorno: JSON.stringify(response.data, null, 2) }));
    }
    componentWillMount() {
        this.listar();
    }
    render() {
        return (
            <div className="App">
                <header className="App-header">
                    <img src={logo} className="App-logo" alt="logo" />
                    <h1 className="App-title">Welcome to React</h1>
                </header>
                <p className="App-intro">
                    To get started, edit <code>src/App.js</code> and save to reload.
                </p>
                <BotaoContador valorInicial={4} {...this.props}>teste</BotaoContador>
                <BotaoContador valorInicial="1" />
                <pre>{this.state.retorno}</pre>
            </div>
        );
    }
}

export default App;
