# Tales Tools - Ragnatales

Este projeto e uma adaptacao do projeto 4RTools para uso pessoal e como objeto de estudo, onde acrescento features na ferramenta para atender as minhas necessidades jogando no servidor Ragnatales.

**ESTA VERSAO E UMA VERSAO EXTENDIDA DA ORIGINAL, CONTENDO TODAS AS FUNCIONALIDADES ORIGINAIS E ALGUMAS CUSTOMIZADAS**

## Rodando o projeto

Caso voce queira usar esta versao do 4rTools voce pode baixar 'https://github.com/biancaazuma/TalesTools/releases/download/v.3.1.0/TalesTools-v3.1.0.rar' com a release que esta na raiz do projeto, ou usando o Visual Studio 2022 abrir o `4RTools.sln` e rodar e gerar suas propias releases.

## Copiando perfil

Voce pode copiar e substituir a pastar `Profile` de sua versao anterior do 4RTools para a nova pasta extraida e ambos tem compatibilidade.

## Custom Features
### Versão 3.1.0
- [x] Ajustado Bug troca automatica de munição para skill sem click
- [x] Novo Autobuff-Skill Anel dos nibelungos
- [x] Novo Autobuff-Skill Rufar dos Tambores
- [x] Novo Autobuff-Skill Bala Mágica
- [x] Novo Autobuff-Skill Distorção Arcana
- [x] Novo Autobuff-Skill Renovatio
- [x] Novo Autobuff-Skill Força Titânica
- [x] Adicionado parar heal em instancia competitiva (Não é preciso selecionar nada ele para automaticamente)
- [x] Adicionado parar heal com Frenesi (Não é preciso selecionar nada ele para automaticamente)
- [x] Adicionado parar tudo quando o chat principal é aberto (Não é preciso selecionar nada ele para automaticamente e não funciona em chat privado)(contribuição do endereço pelo @Rod)
- [x] Adicionado macro switch com click (original 4rtools)
- [x] Adicionado nova função de equipar item antes de potar
- [x] Adicionado 5 Atk x Def (totalizando 8)
- [x] Adicionado botão de prioridade (Pausa AutoBuffs e Autopot quando pressionado e manda a tecla pressionada pro jogo, o delay é a demora de mandar a tecla pressionada)
- [x] Adicionado nova aba de Auto Switch Heal
    - auto switch heal para HP e SP (recomendo usar um ou outro se o equipamento for do mesmo tipo (por ex: baixo, meio, topo), o delay é em segundos, e a cada x segundos ele valida o hp e sp e usa o item de acordo com a porcentagem colocada
    - auto switch heal Pet masterball Professora Célia ( se abaixar de X porcentagem de SP, ele equipa a celia e usa a skill indulgir Y vezes, depois muda para o melhor pet, o delay é relacionado ao apertar a skill)

### Versão 3.0.0
- [x] Removido Auto switch de GTB
- [x] Ajustado Auto switch de Vajra
- [x] Ajustado config descer da redea skill sem click
- [x] Ajustado Nomes em Ordem de autobuffs (Provocar, Rapidez com Uma Mão, Impacto Explosivo, União Solar, Lunar e Estelar)
- [x] Adicionado campo delay para Autobuff-Skills e Autobuff-Stuffs
- [x] Novo Autobuff-Skills de Desejo das Sombras
- [x] Novo Autobuff-Skills de Bater em retirada
- [x] Novo Autobuff-Skills de kaizel
- [x] Novo Autobuff-Skills de kaahi
- [x] Novo Autobuff-Skills de kaite
- [x] Novo Autobuff-Skills de kaupe
- [x] Adicionado botões numéricos Skill Spammer
- [x] Adicionado nova aba grande de Auto Switch
    - auto switch genérico
    - auto switch pets masterball (Eddga, Mestre-ferreiro Howard, Arquimaga Kathryne, Venomorfo Perfeito e Fenrir)
- [x] Nova config de pausar TalesTools quando aparecer o Anti-Bot (contribuição do id pelo Argilago)

### Versão 2.7.4
- [x] Ajustado Bugs AutoSwitch vajra
- [x] Ajustado spam da habilidade Rapidez com Duas Mãos quando estiver no pântano dos mortos
- [x] Separado Parar autobuff/cura na cidade
- [x] Novo Autobuff-Skills de Provocar
- [x] Novo Autobuff-Skills de União Solar, Lunar e Estelar
- [x] Adicionado botão de reset para Autobuff-Skills e Autobuff-Stuffs
- [x] Adicionado tooltips em algumas funções
- [x] Novo Autobuff-Stuffs de Elixir Rubro
- [x] Novo Autobuff-Stuffs de Poção do Dragão Místico
- [x] Novo Autobuff-Stuffs de Poção do Bovino Furioso
- [x] Nova config de desmontar da rédea ao atacar (feito pelo @LordVince  )
- [x] Nova config de troca automatica de munição (feito pelo @LordVince  )

### Versão 2.7.1
- [x] Adicionado 2 Macro Switch (feito pelo @Fabrin )
- [x] Adicionado Auto switch GTB
- [x] Novo Autobuff-Skills de Enlouquecedor
- [x] Ajustado Bugs AutoSwitch
- [x] Ajustado Bugs ATK X DEF
- [x] Ajustado Bugs Macro Songs

### Versão 2.7.0
- [x] Corrigido Autobuff-Stuffs de Poção do Furor Mágico

### Versão 2.6.9
- [x] Ajustado ATK x DEF para mesmo item

### Versão 2.6.8
- [x] Ajustado spam da habilidade Rapidez com Uma Mão quando estiver no pântano dos mortos
- [x] Novo Autobuff-Stuffs de Suco de Gato
- [x] Novo Autobuff-Stuffs de Poção Mental
- [x] Novo Autobuff-Stuffs de Poção Vitata 500
- [x] Novo Autobuff-Stuffs de Salada de Frutas Tropicais
- [x] Novo Autobuff-Stuffs de Cálice da Ilusão
- [x] Novo Autobuff-Stuffs de Pergaminho de Esquiva
- [x] Novo Autobuff-Stuffs de Pergaminho de Precisão
- [x] Novo Debuffs de Incêndio
- [x] Novo Debuffs de Grito da Mandrágora
- [x] Novo Debuffs de Conjuração Lenta
- [x] Adicionado 3 Atk x Def (totalizando 4) (obs: não colocar mesma spammer key para 2 atk x def, algum não irá funcionar)
- [x] Adicionado nova aba de Config (configurações de perfil)
	- Ordenar uso de Autobuffs Skill
	- Pausar autobuffs/pot/skill timer/auto switch na cidade (feito pelo @LordVince)
	- Pausar autobuff-skill na rédea (feito pelo @LordVince)
- [x] Ajustado Doce de Elvira remove debuffs 
	- Conjuração Lenta
	- Ferimento Crítico
	- Hipotermia
	- Grito da Mandrágora
	- Incêndio
	- Sono Profundo

### Versão 2.6.7
- [x] Ajustado delay do auto switch de nariz de dissimulado
- [x] Ajustado desligar bot quando muda de perfil

### Versão 2.6.6
- [x] Ajustado spam da habilidade rapidez com  duas mãos, rapidez com uma mão, Adrenalina Pura, Adrenalina Concentrada quando estiver com diminuir agilidade
- [x] Adicionado 2 Skill Timer (totalizando 4)
- [x] Movido Panacéia e Doce de Elvira para aba de debuffs
- [x] Alterado icone de bala de guaraná + poção da concentração
- [x] Adicionado botão para ligar/desligar apenas pot (se quiser continuar com o 4rtools como está atuamente só colocar o mesmo botão nos 2)
- [x] Adicionado nova aba de Auto Switch de baixos (nariz de dissimulado e vajra)
- [x] Nova Skill de Espadachim (Rapidez com Uma Mão)
- [x] Ajustado spam da habilidade Caminho do Vento quando estiver em cima do pântano dos mortos

### Versão 2.6.5
- [x] Adicionado botão para ativar/desativar a pot quando estiver com Ferimento Crítico (se estiver selecionado não vai curar quando estiver com ferimento critico)
- [x] Novo Debuffs de sentar (se o boss mandar sentar ele levanta sozinho, mas tem que associar sua tecla de sentar lá)
- [x] Nova Skill de Arqueiro (Dança com Lobos)

### Versão 2.6.4
- [x] Adicionado chapéu aba de ATK x DEF
- [x] Ajustado spam da habilidade Rapidez com Lança quando estiver em cima do pântano dos mortos
- [x] Adicionado 2 Macro Switch (ja está no Max totalizando 8)
- [x] Adicionado 4 Macro Songs (ja está no Max totalizando 8)
- [x] Para cura de pot de hp quando estiver com ferimento critico (Ygg funciona normalmente)
- [x] Adicionado pergaminhos de cheffenia (Ghostring, Angeling, Tao Gunka, Senhor dos Orcs, Orc Herói, Abelha Rainha)
- [x] Novo Autobuff-Stuffs de  Manual de Combate de Classe
- [x] Alterado icone de Goma
- [x] Nova Skill de Noviço (Basílica)

### Versão 2.6.2
- [x] Adicionado nova aba de Debuffs (para quem utiliza a pot para debuffs específicos )
- [x] Novo Autobuff-Stuffs de Incenso queimado
- [x] Novo Autobuff-Stuffs de Acarajé
- [x] Novo Autobuff-Stuffs de Palitos (Laranja/Baunilha/Cassis/Chocolate/Limão/Morango)

### Versão 2.6.1
- [x] Adicionado seleção de prioridade de cura para HP/SP
- [x] Novo Autobuff-Stuffs de Pergaminho do eden
- [x] Novo Autobuff-Stuffs de Pergaminho de aspersio
- [x] Novo Autobuff-Stuffs de Pergaminho de fantasma
- [x] Nova Skill de Noviço (Lauda Agnus)
- [x] Nova Skill de Noviço (Lauda Ramus)
- [x] Nova Skill de Espadachim (Impacto Explosivo)
- [x] Adicionado mais 3 macro switchs
- [x] Adicionado mais 1 Skill Timer
- [x] Correção Aloe Vera (ragnatales é diferente)

### Versão 2.6.0
- [x] Modo Escuro
- [x] Auto-Transfer Itens
- [x] Novas Skills de Sumo (Impositio Manus)
- [x] Nova Skill de Archer (Disparo Selvagem)
- [x] Nova Skill de Mestre Taekwon (Milagre solar, Lunar e Estelar)
- [x] Nova Skill de Mestre Taekwon (Calor solar, Lunar e Estelar)
- [x] Nova Skill de Mestre Taekwon (Proteção Solar)
- [x] Nova Skill de Mestre Taekwon (Proteção Lunar)
- [x] Nova Skill de Mestre Taekwon (Proteção Estelar)
- [x] Correção Vigor Auto-Spawn
- [x] Nova Skill de Ninja (Imagem Falsa)
- [x] Nova Skill de Justiceiro (Reação Ilimitada)
- [x] Nova Skill de Gatuno (Esconderijo)
- [x] Nova Skill de Gatuno (Furtividade)
- [x] Novo Autobuff-Stuffs de Veneno para gatunos
## Original Features
- [x] ON/OFF Button (with shortcut key)
- [x] Autopot
- [x] Autobuff status
- [x] Manage Profiles
- [x] AHK Spammer
- [x] Auto Refresh Spammer
- [x] Autobuff Stuffs
- [x] Autobuff skills
- [x] Song Macro
- [x] Macro Switch/Macro Chain
- [x] ATK x DEF Mode switch
