import React, { Component } from 'react';

class BotaoContador extends Component {
    constructor(props) {
        super(props);
        console.log(this.props);
        this.state = {
            valor: props.valorInicial ? props.valorInicial : 0,
        };
    }

    clicou = () => {
        this.setState({ valor: this.state.valor + 1 });
    }

    render() {
        const { valor } = this.state;
        return (
            <div>
                Teste: {valor}
                <br />
                <button onClick={this.clicou}>Clique Aqui</button>
                {this.props.children}
            </div>
        );
    }
}

export default BotaoContador;
